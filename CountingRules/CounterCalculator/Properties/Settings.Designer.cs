﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CountingRules.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsAverageLengthofWordsStartingwithLetterApplicable {
            get {
                return ((bool)(this["IsAverageLengthofWordsStartingwithLetterApplicable"]));
            }
            set {
                this["IsAverageLengthofWordsStartingwithLetterApplicable"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("average_length_of_words_starting_with_a")]
        public string AverageLengthofWordsStartingwithLetterResultFile {
            get {
                return ((string)(this["AverageLengthofWordsStartingwithLetterResultFile"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IsCountCharsinWordsStartingWithLetterApplicable {
            get {
                return ((bool)(this["IsCountCharsinWordsStartingWithLetterApplicable"]));
            }
            set {
                this["IsCountCharsinWordsStartingWithLetterApplicable"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("count_of_e_in_words_starting_with_b")]
        public string CountCharsinWordsStartingWithLetterResultFile {
            get {
                return ((string)(this["CountCharsinWordsStartingWithLetterResultFile"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IsLongestWordStartingwithLetterApplicable {
            get {
                return ((bool)(this["IsLongestWordStartingwithLetterApplicable"]));
            }
            set {
                this["IsLongestWordStartingwithLetterApplicable"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("longest_words_starting_with_abc")]
        public string LongestWordStartingwithLetterResultFile {
            get {
                return ((string)(this["LongestWordStartingwithLetterResultFile"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IsCountSequenceOfWordsStartingWithLettersApplicable {
            get {
                return ((bool)(this["IsCountSequenceOfWordsStartingWithLettersApplicable"]));
            }
            set {
                this["IsCountSequenceOfWordsStartingWithLettersApplicable"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("count_of_sequence_of_words_starting_withs_c_and_a")]
        public string CountSequenceOfWordsStartingWithLettersResultFile {
            get {
                return ((string)(this["CountSequenceOfWordsStartingWithLettersResultFile"]));
            }
        }
    }
}