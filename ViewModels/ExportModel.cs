using System;
using System.Collections.Generic;
public class ExportModel {
    public string title { get; set; }
    public int? orderIndex { get; set; }
    public string password { get; set; }
    public double ratio { get; set; }
    public int? caseType { get; set; }
    public int? countTime { get; set; }
    public int? unitTime { get; set; }
    public int? boxCount { get; set; }
    public int? languageItemOne { get; set; }
    public int? languageItemTwo { get; set; }
    public int? languageItemThree { get; set; }
    public int? rootGroupId { get; set; }
    public string imagePath { get; set; }
    public IEnumerable<lesson> lessons { get; set; }

}
public class lesson {
    public string title { get; set; }
    public int? orderIndex { get; set; }
    public string imagePath { get; set; }
    public string storyTitle { get; set; }
    public string storyDesc { get; set; }
    public string storyImagePath { get; set; }
    public string storyVoicePathOne { get; set; }
    public string storyVoicePathTwo { get; set; }
    public string descriptionTitle { get; set; }
    public string descriptionDesc { get; set; }
    public string descriptionImagePath { get; set; }
    public string descriptionVoicePathOne { get; set; }
    public string descriptionVoicePathTwo { get; set; }
    public int? subGroupId { get; set; }
    public IEnumerable<CardApi> cards { get; set; }

}
public class CardApi {
    public string question { get; set; }
    public int? orderIndex { get; set; }
    public string questionVoicePath { get; set; }
    public double ratio { get; set; }
    public string reply { get; set; }
    public string replyVoicePath { get; set; }
    public string description { get; set; }
    public string descriptionVoicePath { get; set; }
    public string imagePath { get; set; }
    public string dateCreated { get; set; }
    public bool? examDone { get; set; }
    public int? boxNumber { get; set; }
    public string boxVisibleDate { get; set; }
    public int? lessonId { get; set; }

    // SqfEntityField('serverId', DbType.integer),
    //   SqfEntityField('orderIndex', DbType.integer),
    //   SqfEntityField('serverSync', DbType.bool),
    //   SqfEntityField('videoUrl', DbType.text),
    //   SqfEntityField('spellChecker', DbType.bool, defaultValue: false),
    //   SqfEntityField('question', DbType.text),
    //   SqfEntityField('questionVoicePath', DbType.text),
    //   SqfEntityField('ratio', DbType.real),
    //   SqfEntityField('reply', DbType.text),
    //   SqfEntityField('replyVoicePath', DbType.text),
    //   SqfEntityField('description', DbType.text),
    //   SqfEntityField('descriptionVoicePath', DbType.text),
    //   SqfEntityField('imagePath', DbType.text),
    //   SqfEntityField('dateCreated', DbType.datetime),
    //    SqfEntityField('reviewStart', DbType.bool, defaultValue: false),
    //   SqfEntityField('examDone', DbType.bool, defaultValue: false),
    //   SqfEntityField('autoPlay', DbType.bool, defaultValue: true),
    //   SqfEntityField('autoRecord', DbType.bool, defaultValue: true),
    //   SqfEntityField('boxNumber', DbType.integer, defaultValue: 0),
    //   SqfEntityField('boxVisibleDate', DbType.datetime),

}