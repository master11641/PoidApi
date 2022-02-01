(function ($) {
    $.fn.PostMvcFormAjax = function (options) {
        var defaults = {
            postUrl: '/',
            loginUrl: '/login',
            beforePostHandler: null,
            completeHandler: null,
            errorHandler: null
        };
        var options = $.extend(defaults, options);

        var validateForm = function (form) {
            //برای فعال کردن اعتبار سنجی زمانی که فرم ایجکسی به صفحه تزریق شده است
            $.validator.unobtrusive.parse("#tjaxModal");
            //فعال سازی دستی اعتبار سنجی جی‌کوئری
            var val = form.validate();
            val.form();
            return val.valid();
        };

        return this.each(function () {
            var form = $(this);
            //اگر فرم اعتبار سنجی نشده، اطلاعات آن ارسال نشود
            if (!validateForm(form)) return;
            //در اینجا می‌توان مثلا دکمه‌ای را غیرفعال کرد
            if (options.beforePostHandler)
                options.beforePostHandler(this);

            //اطلاعات نباید کش شوند
            $.ajaxSetup({ cache: false });

            $.ajax({
                type: "POST",
                url: options.postUrl,
                data: form.serialize(), //تمام فیلدهای فرم منجمله آنتی فرجری توکن آن‌را ارسال می‌کند
                complete: function (xhr, status) {
                    var data = xhr.responseText;
                    if (xhr.status == 200) {
                        var jsonData = JSON.parse(data);
                        if (typeof jsonData.Errors != 'undefined') {
                            errors = JSON.parse(data).Errors;
                            var errorMsg = '';
                            for (var i = 0; i < errors.length; i++) {
                                errorMsg += errors[i].Value[0] + '\r\n';
                            }
                            alert(errorMsg);
                            status = 'error';
                        }
                    }
                    if (xhr.status == 403) {
                        window.location = options.loginUrl; //در حالت لاگین نبودن شخص اجرا می‌شود
                    }
                    else if (status === 'error' || !data) {
                        if (options.errorHandler) {
                            options.errorHandler(this);
                        }
                    }
                    else {
                        if (options.completeHandler)
                            options.completeHandler(this, xhr.responseText);
                    }
                }
            });
        });
    };
})(jQuery);
(function ($) {
    $.fn.tjax = function (options) {
        var defaults = {
            scope: 'body',
            record: 'true',
            popup: 'false',
            postUrl: '/',
            loginUrl: '/login',
            method: 'GET',
            forSendForm: null,
            showWaiting: true,
            injectResponseToScope: 'true',
            beforePostHandler: null,
            completeHandler: null,
            errorHandler: null
        };
        var options = $.extend(defaults, options);
        $("body").append(BuildModal());
        window.onpopstate = function (event) {
            if (event.state) {
                options.postUrl = event.state.url;
                options.scope = event.state.scope;
                GetTjax('false');
            }
        }
        function BuildModal() {
            var modal = '<div id="tjaxModal" class="modal" >';
            modal += ' <div class="modal-dialog " ><div class="modal-content"><div class="modal-header">  ';
            modal += '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">× </button>';
            modal += '<button type="button" id="modalmaximize" class="close" style="margin-left:5px;margin-top:1px;"  ><i class=" fa fa-square-o "></i></button>    ';
            modal += '<button type="button" id="modalminimize" class="close" style="margin-left:5px;margin-top:1px;display:none;"  ><i class=" fa fa-external-link  "></i></button>  ';
            modal += ' <h5 id="myModalLabel">----</h5> </div>';
            modal += ' <div class="modal-body tjax-body" style="overflow-y:auto;height:500px;"></div> </div> </div> </div>';
            return modal;
        }//BuildModal function
        if (options.showWaiting) {
            $(document).on({
                ajaxStart: function() {
                    $(defaults.scope).addClass("loading");
                    $(defaults.scope).append('<div class="spinner"></div>');
                },
                ajaxStop: function() {
                    $(defaults.scope).removeClass("loading");
                    $(".spinner").remove();
                }
            });
        }
        function GetTjax(popup) {
            $.ajax({
                method: options.method,
                url: options.postUrl,
                headers: { 'x-tjax': 'true' },
                data: {},
                complete: function (xhr, status) {
                    if (status == 'success') {
                        // var title = $(xhr.responseText).filter('title').text();
                        if (options.record == 'true') {
                            history.pushState({ scope: options.scope, url: options.postUrl }, $(xhr.responseText).filter('title').text(), options.postUrl);
                            document.title = $(xhr.responseText).filter('title').text();
                        }

                        if (popup == "true" || !options.scope) {
                            $('.tjax-body').html(xhr.responseText);
                            $('#myModalLabel').html($(xhr.responseText).filter('title').text());
                            $('#tjaxModal').modal('show');
                        } else if (options.injectResponseToScope == "true")
                        { $(options.scope).html(xhr.responseText); }
                        if (options.completeHandler != null)
                            // options.completeHandler(this, xhr.responseText);
                            window[options.completeHandler](this, xhr.responseText);
                    }
                    if (xhr.status == 403) {
                        window.location = options.loginUrl;
                    }
                    if (status == 'error' || !xhr.responseText) {
                        if (options.errorHandler)
                            options.errorHandler(this);
                    }
                }
            });
        } //Gettjax function
        return this.each(function () {
            var popup = $(this).attr('popup');
            options.postUrl = ($(this).attr('href') != null) ? $(this).attr('href') : options.postUrl;
            options.scope = ($(this).attr('scope') != null) ? $(this).attr('scope') : options.scope;
            options.injectResponseToScope = ($(this).attr('injectResponseToScope') != null) ? $(this).attr('injectResponseToScope') : options.injectResponseToScope;
            options.record = ($(this).attr('record') != null) ? $(this).attr('record') : 'true';
            options.forSendForm = ($(this).attr('forSendForm') != null) ? $(this).attr('forSendForm') : null;
            options.method = ($(this).attr('method') != null) ? $(this).attr('method') : 'GET';
            options.completeHandler = ($(this).attr('completeHandler') != null) ? $(this).attr('completeHandler') : null;
            if (popup == 'true' || options.forSendForm) {
                options.record = 'false';
            }

            if (options.forSendForm) {
                var button = $(this);
                $(options.forSendForm).PostMvcFormAjax({
                    postUrl: options.postUrl,
                    loginUrl: options.loginUrl,
                    beforePostHandler: function () {
                        //غیرفعال سازی دکمه ارسال
                        button.attr('disabled', 'disabled');
                        button.val("...");
                    },
                    completeHandler: function (sender, response) {
                        if (options.completeHandler != null) {
                            window[options.completeHandler](sender, response);
                        }
                        if (typeof completeHandler == "function") {
                            completeHandler(button, response);
                        }

                        button.removeAttr('disabled');
                    },
                    errorHandler: function () {
                        alert('خطایی رخ داده است');
                        button.removeAttr('disabled');
                    }
                });
            }
            else {
                GetTjax(popup);
            }
        });
    };
})(jQuery);
(function ($) {
    $.fn.fielddescription = function () {
        return this.each(function () {
            $(this).append(' <span data-placement="bottom" data-toggle="popover" style="width:20px;height:20px;cursor:pointer;color:blue;" title="' + $(this).text() + '" data-trigger="hover" data-content="' + $(this).attr("data-description") + '">  <i   class="fa  fa-question-circle"></i></span>');
            $('[data-toggle="popover"]').popover();
            $(this).removeAttr("data-description");
        });
    }
}
)(jQuery)