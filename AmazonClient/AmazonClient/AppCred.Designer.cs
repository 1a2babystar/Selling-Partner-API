﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmazonClient {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class AppCred : global::System.Configuration.ApplicationSettingsBase {
        
        private static AppCred defaultInstance = ((AppCred)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new AppCred())));
        
        public static AppCred Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://api.amazon.com/auth/o2/token")]
        public string Endpoint {
            get {
                return ((string)(this["Endpoint"]));
            }
            set {
                this["Endpoint"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string AccessToken {
            get {
                return ((string)(this["AccessToken"]));
            }
            set {
                this["AccessToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("amzn1.application-oa2-client.502e569081ba4831b215e0a00bb65003")]
        public string ClientId {
            get {
                return ((string)(this["ClientId"]));
            }
            set {
                this["ClientId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("76c1b532a1753b6bc070d6031a02d89c02903de22e6dea3f16936864a4ac04f3")]
        public string ClientSecret {
            get {
                return ((string)(this["ClientSecret"]));
            }
            set {
                this["ClientSecret"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"Atzr|IwEBILFMMxq0CvbB97j8BbT8tk1JNqpfsAqzFGEYncUFqaXM2fKz14NKETtHjUrvhW9hCKufNelmB0_ieMm0n6qBYvl4Dyt-6BUwG_IuHVnuBONWl_rLtmJDQeyryygPQ0DpXrdyX7kUEMIqt89nvMSDbv9-bAl3LySsjy-fS1_fOMw2Xk2qkLj0k2XVmApMmotvROekHNUdMtmLpUe8lD0I5qFyIfbIt0Z3Wyd4AnZpuGojhvi_td9-dSyt1dj3OHtY0see8FRWmJZLzDy2744IGVl5JHSbppwvy5T1oh-0RLLwKw56n_2Jl6vxBfpw_QbMi1w")]
        public string RefreshToken {
            get {
                return ((string)(this["RefreshToken"]));
            }
            set {
                this["RefreshToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("us-east-1")]
        public string Region {
            get {
                return ((string)(this["Region"]));
            }
            set {
                this["Region"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AKIARW6B67MQXBT2XTVN")]
        public string AccessKeyId {
            get {
                return ((string)(this["AccessKeyId"]));
            }
            set {
                this["AccessKeyId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tDjdDgsFOUub7AcEsk1DOr97V7oiFKmzC5tFYrLv")]
        public string SecretKey {
            get {
                return ((string)(this["SecretKey"]));
            }
            set {
                this["SecretKey"] = value;
            }
        }
    }
}
