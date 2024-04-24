using Microsoft.Fast.Components.FluentUI;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Fast.Components.FluentUI;

// Icons Color: #444791

public static class MyIcons
{
    public static class Regular
    {
        [ExcludeFromCodeCoverage]
        public static class Size10
        {
            public class Auth : Icon
            {
                public Auth()
                    : base("Auth",
                            IconVariant.Regular,
                            IconSize.Size10,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472L29.01 41.21l-.732 1.29l-5-2.515l-4.047-14.158\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472c-6.605.37-12.467-3.46-11.261-11.166\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M9.675 19.277a7.41 7.41 0 1 1 11.133-5.334\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m29.337 19.411l12.554 11.947l.05 2.497l-5.634.03l-10.95-10.738m-.013.005a7.112 7.112 0 0 1-9.601-6.661h0a7.11 7.11 0 0 1 7.11-7.111h0a7.11 7.11 0 0 1 7.112 7.11h0a7.1 7.1 0 0 1-.623 2.91\" />\r\n</svg>"
                          )
                {
                }
            }
            public class People : Icon
            {
                public People()
                    : base("People",
                            IconVariant.Regular,
                            IconSize.Size10,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 15 15\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 14.49v.5h.5v-.5zm-10 0H0v.5h.5zm14 .01v.5h.5v-.5zM8 3.498a2.499 2.499 0 0 1-2.5 2.498v1C7.433 6.996 9 5.43 9 3.498zM5.5 5.996A2.499 2.499 0 0 1 3 3.498H2a3.499 3.499 0 0 0 3.5 3.498zM3 3.498A2.499 2.499 0 0 1 5.5 1V0A3.499 3.499 0 0 0 2 3.498zM5.5 1A2.5 2.5 0 0 1 8 3.498h1A3.499 3.499 0 0 0 5.5 0zm5 12.99H.5v1h10zm-9.5.5v-1.995H0v1.995zm2.5-4.496h4v-1h-4zm6.5 2.5v1.996h1v-1.996zm-2.5-2.5a2.5 2.5 0 0 1 2.5 2.5h1a3.5 3.5 0 0 0-3.5-3.5zm-6.5 2.5a2.5 2.5 0 0 1 2.5-2.5v-1a3.5 3.5 0 0 0-3.5 3.5zM14 13v1.5h1V13zm.5 1H12v1h2.5zM12 11a2 2 0 0 1 2 2h1a3 3 0 0 0-3-3zm-.5-3A1.5 1.5 0 0 1 10 6.5H9A2.5 2.5 0 0 0 11.5 9zM13 6.5A1.5 1.5 0 0 1 11.5 8v1A2.5 2.5 0 0 0 14 6.5zM11.5 5A1.5 1.5 0 0 1 13 6.5h1A2.5 2.5 0 0 0 11.5 4zm0-1A2.5 2.5 0 0 0 9 6.5h1A1.5 1.5 0 0 1 11.5 5z\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Users : Icon
            {
                public Users()
                    : base("Users",
                            IconVariant.Regular,
                            IconSize.Size10,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M11.5 6A3.514 3.514 0 0 0 8 9.5c0 1.922 1.578 3.5 3.5 3.5S15 11.422 15 9.5S13.422 6 11.5 6m9 0A3.514 3.514 0 0 0 17 9.5c0 1.922 1.578 3.5 3.5 3.5S24 11.422 24 9.5S22.422 6 20.5 6m-9 2c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5m9 0c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5M7 12c-2.2 0-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 2 23h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C10.523 18.117 11 17.114 11 16c0-2.2-1.8-4-4-4m5 11c-.625.836-1 1.887-1 3h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.024 5.024 0 0 0-1-3c-.34-.453-.75-.84-1.219-1.156C19.523 21.117 20 20.114 20 19c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.042 5.042 0 0 0 12 23m8 0h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C28.523 18.117 29 17.114 29 16c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 20 23M7 14c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m18 0c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m-9 3c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Roles : Icon
            {
                public Roles()
                    : base("Roles",
                            IconVariant.Regular,
                            IconSize.Size10,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M19.307 3.21a2.91 2.91 0 1 0-.223 1.94a11.636 11.636 0 0 1 8.232 7.049l1.775-.698a13.576 13.576 0 0 0-9.784-8.291m-2.822 1.638a.97.97 0 1 1 0-1.939a.97.97 0 0 1 0 1.94m-4.267.805l-.717-1.774a13.576 13.576 0 0 0-8.291 9.784a2.91 2.91 0 1 0 1.94.223a11.636 11.636 0 0 1 7.068-8.233m-8.34 11.802a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94m12.607 8.727a2.91 2.91 0 0 0-2.599 1.62a11.636 11.636 0 0 1-8.233-7.05l-1.774.717a13.576 13.576 0 0 0 9.813 8.291a2.91 2.91 0 1 0 2.793-3.578m0 3.879a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94M32 16.485a2.91 2.91 0 1 0-4.199 2.599a11.636 11.636 0 0 1-7.05 8.232l.718 1.775a13.576 13.576 0 0 0 8.291-9.813A2.91 2.91 0 0 0 32 16.485m-2.91.97a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94\" />\r\n\t<path fill=\"#444791\" d=\"M19.19 16.35a3.879 3.879 0 1 0-5.42 0a4.848 4.848 0 0 0-2.134 4.014v1.939h9.697v-1.94a4.848 4.848 0 0 0-2.143-4.014m-4.645-2.774a1.94 1.94 0 1 1 3.88 0a1.94 1.94 0 0 1-3.88 0m-.97 6.788a2.91 2.91 0 1 1 5.819 0z\" class=\"ouiIcon__fillSecondary\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Permissions : Icon
            {
                public Permissions()
                    : base("Permissions",
                            IconVariant.Regular,
                            IconSize.Size10,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M22.2 4.86L6.69 11.25V27C6.69 35.44 24 43.5 24 43.5S41.31 35.44 41.31 27V11.25L25.8 4.86a4.68 4.68 0 0 0-3.6 0M24 43.5v-39M6.69 24h34.62\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Clients : Icon
            {
                public Clients()
                    : base("Clients",
                            IconVariant.Regular,
                            IconSize.Size10,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M29.755 21.345A1 1 0 0 0 29 21h-2v-2c0-1.102-.897-2-2-2h-4c-1.103 0-2 .898-2 2v2h-2a1.001 1.001 0 0 0-.99 1.142l1 7A1 1 0 0 0 18 30h10a1 1 0 0 0 .99-.858l1-7a1.001 1.001 0 0 0-.235-.797M21 19h4v2h-4zm6.133 9h-8.266l-.714-5h9.694zM10 20h2v10h-2z\" />\r\n\t<path fill=\"#444791\" d=\"m16.78 17.875l-1.906-2.384l-1.442-3.605A2.986 2.986 0 0 0 10.646 10H5c-1.654 0-3 1.346-3 3v7c0 1.103.897 2 2 2h1v8h2V20H4v-7a1 1 0 0 1 1-1h5.646c.411 0 .776.247.928.629l1.645 3.996l2 2.5zM4 5c0-2.206 1.794-4 4-4s4 1.794 4 4s-1.794 4-4 4s-4-1.794-4-4m2 0c0 1.103.897 2 2 2s2-.897 2-2s-.897-2-2-2s-2 .897-2 2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Emails : Icon
            {
                public Emails()
                    : base("Emails",
                            IconVariant.Regular,
                            IconSize.Size10,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                          )
                {
                }
            }
        }
        [ExcludeFromCodeCoverage]
        public static class Size12
        {
            public class Auth : Icon
            {
                public Auth()
                    : base("Auth",
                            IconVariant.Regular,
                            IconSize.Size12,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472L29.01 41.21l-.732 1.29l-5-2.515l-4.047-14.158\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472c-6.605.37-12.467-3.46-11.261-11.166\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M9.675 19.277a7.41 7.41 0 1 1 11.133-5.334\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m29.337 19.411l12.554 11.947l.05 2.497l-5.634.03l-10.95-10.738m-.013.005a7.112 7.112 0 0 1-9.601-6.661h0a7.11 7.11 0 0 1 7.11-7.111h0a7.11 7.11 0 0 1 7.112 7.11h0a7.1 7.1 0 0 1-.623 2.91\" />\r\n</svg>"
                          )
                {
                }
            }
            public class People : Icon
            {
                public People()
                    : base("People",
                            IconVariant.Regular,
                            IconSize.Size12,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 15 15\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 14.49v.5h.5v-.5zm-10 0H0v.5h.5zm14 .01v.5h.5v-.5zM8 3.498a2.499 2.499 0 0 1-2.5 2.498v1C7.433 6.996 9 5.43 9 3.498zM5.5 5.996A2.499 2.499 0 0 1 3 3.498H2a3.499 3.499 0 0 0 3.5 3.498zM3 3.498A2.499 2.499 0 0 1 5.5 1V0A3.499 3.499 0 0 0 2 3.498zM5.5 1A2.5 2.5 0 0 1 8 3.498h1A3.499 3.499 0 0 0 5.5 0zm5 12.99H.5v1h10zm-9.5.5v-1.995H0v1.995zm2.5-4.496h4v-1h-4zm6.5 2.5v1.996h1v-1.996zm-2.5-2.5a2.5 2.5 0 0 1 2.5 2.5h1a3.5 3.5 0 0 0-3.5-3.5zm-6.5 2.5a2.5 2.5 0 0 1 2.5-2.5v-1a3.5 3.5 0 0 0-3.5 3.5zM14 13v1.5h1V13zm.5 1H12v1h2.5zM12 11a2 2 0 0 1 2 2h1a3 3 0 0 0-3-3zm-.5-3A1.5 1.5 0 0 1 10 6.5H9A2.5 2.5 0 0 0 11.5 9zM13 6.5A1.5 1.5 0 0 1 11.5 8v1A2.5 2.5 0 0 0 14 6.5zM11.5 5A1.5 1.5 0 0 1 13 6.5h1A2.5 2.5 0 0 0 11.5 4zm0-1A2.5 2.5 0 0 0 9 6.5h1A1.5 1.5 0 0 1 11.5 5z\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Users : Icon
            {
                public Users()
                    : base("Users",
                            IconVariant.Regular,
                            IconSize.Size12,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M11.5 6A3.514 3.514 0 0 0 8 9.5c0 1.922 1.578 3.5 3.5 3.5S15 11.422 15 9.5S13.422 6 11.5 6m9 0A3.514 3.514 0 0 0 17 9.5c0 1.922 1.578 3.5 3.5 3.5S24 11.422 24 9.5S22.422 6 20.5 6m-9 2c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5m9 0c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5M7 12c-2.2 0-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 2 23h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C10.523 18.117 11 17.114 11 16c0-2.2-1.8-4-4-4m5 11c-.625.836-1 1.887-1 3h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.024 5.024 0 0 0-1-3c-.34-.453-.75-.84-1.219-1.156C19.523 21.117 20 20.114 20 19c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.042 5.042 0 0 0 12 23m8 0h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C28.523 18.117 29 17.114 29 16c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 20 23M7 14c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m18 0c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m-9 3c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Roles : Icon
            {
                public Roles()
                    : base("Roles",
                            IconVariant.Regular,
                            IconSize.Size12,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M19.307 3.21a2.91 2.91 0 1 0-.223 1.94a11.636 11.636 0 0 1 8.232 7.049l1.775-.698a13.576 13.576 0 0 0-9.784-8.291m-2.822 1.638a.97.97 0 1 1 0-1.939a.97.97 0 0 1 0 1.94m-4.267.805l-.717-1.774a13.576 13.576 0 0 0-8.291 9.784a2.91 2.91 0 1 0 1.94.223a11.636 11.636 0 0 1 7.068-8.233m-8.34 11.802a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94m12.607 8.727a2.91 2.91 0 0 0-2.599 1.62a11.636 11.636 0 0 1-8.233-7.05l-1.774.717a13.576 13.576 0 0 0 9.813 8.291a2.91 2.91 0 1 0 2.793-3.578m0 3.879a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94M32 16.485a2.91 2.91 0 1 0-4.199 2.599a11.636 11.636 0 0 1-7.05 8.232l.718 1.775a13.576 13.576 0 0 0 8.291-9.813A2.91 2.91 0 0 0 32 16.485m-2.91.97a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94\" />\r\n\t<path fill=\"#444791\" d=\"M19.19 16.35a3.879 3.879 0 1 0-5.42 0a4.848 4.848 0 0 0-2.134 4.014v1.939h9.697v-1.94a4.848 4.848 0 0 0-2.143-4.014m-4.645-2.774a1.94 1.94 0 1 1 3.88 0a1.94 1.94 0 0 1-3.88 0m-.97 6.788a2.91 2.91 0 1 1 5.819 0z\" class=\"ouiIcon__fillSecondary\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Permissions : Icon
            {
                public Permissions()
                    : base("Permissions",
                            IconVariant.Regular,
                            IconSize.Size12,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M22.2 4.86L6.69 11.25V27C6.69 35.44 24 43.5 24 43.5S41.31 35.44 41.31 27V11.25L25.8 4.86a4.68 4.68 0 0 0-3.6 0M24 43.5v-39M6.69 24h34.62\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Clients : Icon
            {
                public Clients()
                    : base("Clients",
                            IconVariant.Regular,
                            IconSize.Size12,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M29.755 21.345A1 1 0 0 0 29 21h-2v-2c0-1.102-.897-2-2-2h-4c-1.103 0-2 .898-2 2v2h-2a1.001 1.001 0 0 0-.99 1.142l1 7A1 1 0 0 0 18 30h10a1 1 0 0 0 .99-.858l1-7a1.001 1.001 0 0 0-.235-.797M21 19h4v2h-4zm6.133 9h-8.266l-.714-5h9.694zM10 20h2v10h-2z\" />\r\n\t<path fill=\"#444791\" d=\"m16.78 17.875l-1.906-2.384l-1.442-3.605A2.986 2.986 0 0 0 10.646 10H5c-1.654 0-3 1.346-3 3v7c0 1.103.897 2 2 2h1v8h2V20H4v-7a1 1 0 0 1 1-1h5.646c.411 0 .776.247.928.629l1.645 3.996l2 2.5zM4 5c0-2.206 1.794-4 4-4s4 1.794 4 4s-1.794 4-4 4s-4-1.794-4-4m2 0c0 1.103.897 2 2 2s2-.897 2-2s-.897-2-2-2s-2 .897-2 2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Emails : Icon
            {
                public Emails()
                    : base("Emails",
                            IconVariant.Regular,
                            IconSize.Size12,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                          )
                {
                }
            }
        }
        [ExcludeFromCodeCoverage]
        public static class Size16
        {
            public class Auth : Icon
            {
                public Auth()
                    : base("Auth",
                            IconVariant.Regular,
                            IconSize.Size16,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472L29.01 41.21l-.732 1.29l-5-2.515l-4.047-14.158\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472c-6.605.37-12.467-3.46-11.261-11.166\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M9.675 19.277a7.41 7.41 0 1 1 11.133-5.334\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m29.337 19.411l12.554 11.947l.05 2.497l-5.634.03l-10.95-10.738m-.013.005a7.112 7.112 0 0 1-9.601-6.661h0a7.11 7.11 0 0 1 7.11-7.111h0a7.11 7.11 0 0 1 7.112 7.11h0a7.1 7.1 0 0 1-.623 2.91\" />\r\n</svg>"
                          )
                {
                }
            }
            public class People : Icon
            {
                public People()
                    : base("People",
                            IconVariant.Regular,
                            IconSize.Size16,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 15 15\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 14.49v.5h.5v-.5zm-10 0H0v.5h.5zm14 .01v.5h.5v-.5zM8 3.498a2.499 2.499 0 0 1-2.5 2.498v1C7.433 6.996 9 5.43 9 3.498zM5.5 5.996A2.499 2.499 0 0 1 3 3.498H2a3.499 3.499 0 0 0 3.5 3.498zM3 3.498A2.499 2.499 0 0 1 5.5 1V0A3.499 3.499 0 0 0 2 3.498zM5.5 1A2.5 2.5 0 0 1 8 3.498h1A3.499 3.499 0 0 0 5.5 0zm5 12.99H.5v1h10zm-9.5.5v-1.995H0v1.995zm2.5-4.496h4v-1h-4zm6.5 2.5v1.996h1v-1.996zm-2.5-2.5a2.5 2.5 0 0 1 2.5 2.5h1a3.5 3.5 0 0 0-3.5-3.5zm-6.5 2.5a2.5 2.5 0 0 1 2.5-2.5v-1a3.5 3.5 0 0 0-3.5 3.5zM14 13v1.5h1V13zm.5 1H12v1h2.5zM12 11a2 2 0 0 1 2 2h1a3 3 0 0 0-3-3zm-.5-3A1.5 1.5 0 0 1 10 6.5H9A2.5 2.5 0 0 0 11.5 9zM13 6.5A1.5 1.5 0 0 1 11.5 8v1A2.5 2.5 0 0 0 14 6.5zM11.5 5A1.5 1.5 0 0 1 13 6.5h1A2.5 2.5 0 0 0 11.5 4zm0-1A2.5 2.5 0 0 0 9 6.5h1A1.5 1.5 0 0 1 11.5 5z\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Users : Icon
            {
                public Users()
                    : base("Users",
                            IconVariant.Regular,
                            IconSize.Size16,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M11.5 6A3.514 3.514 0 0 0 8 9.5c0 1.922 1.578 3.5 3.5 3.5S15 11.422 15 9.5S13.422 6 11.5 6m9 0A3.514 3.514 0 0 0 17 9.5c0 1.922 1.578 3.5 3.5 3.5S24 11.422 24 9.5S22.422 6 20.5 6m-9 2c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5m9 0c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5M7 12c-2.2 0-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 2 23h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C10.523 18.117 11 17.114 11 16c0-2.2-1.8-4-4-4m5 11c-.625.836-1 1.887-1 3h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.024 5.024 0 0 0-1-3c-.34-.453-.75-.84-1.219-1.156C19.523 21.117 20 20.114 20 19c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.042 5.042 0 0 0 12 23m8 0h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C28.523 18.117 29 17.114 29 16c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 20 23M7 14c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m18 0c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m-9 3c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Roles : Icon
            {
                public Roles()
                    : base("Roles",
                            IconVariant.Regular,
                            IconSize.Size16,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M19.307 3.21a2.91 2.91 0 1 0-.223 1.94a11.636 11.636 0 0 1 8.232 7.049l1.775-.698a13.576 13.576 0 0 0-9.784-8.291m-2.822 1.638a.97.97 0 1 1 0-1.939a.97.97 0 0 1 0 1.94m-4.267.805l-.717-1.774a13.576 13.576 0 0 0-8.291 9.784a2.91 2.91 0 1 0 1.94.223a11.636 11.636 0 0 1 7.068-8.233m-8.34 11.802a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94m12.607 8.727a2.91 2.91 0 0 0-2.599 1.62a11.636 11.636 0 0 1-8.233-7.05l-1.774.717a13.576 13.576 0 0 0 9.813 8.291a2.91 2.91 0 1 0 2.793-3.578m0 3.879a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94M32 16.485a2.91 2.91 0 1 0-4.199 2.599a11.636 11.636 0 0 1-7.05 8.232l.718 1.775a13.576 13.576 0 0 0 8.291-9.813A2.91 2.91 0 0 0 32 16.485m-2.91.97a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94\" />\r\n\t<path fill=\"#444791\" d=\"M19.19 16.35a3.879 3.879 0 1 0-5.42 0a4.848 4.848 0 0 0-2.134 4.014v1.939h9.697v-1.94a4.848 4.848 0 0 0-2.143-4.014m-4.645-2.774a1.94 1.94 0 1 1 3.88 0a1.94 1.94 0 0 1-3.88 0m-.97 6.788a2.91 2.91 0 1 1 5.819 0z\" class=\"ouiIcon__fillSecondary\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Permissions : Icon
            {
                public Permissions()
                    : base("Permissions",
                            IconVariant.Regular,
                            IconSize.Size16,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M22.2 4.86L6.69 11.25V27C6.69 35.44 24 43.5 24 43.5S41.31 35.44 41.31 27V11.25L25.8 4.86a4.68 4.68 0 0 0-3.6 0M24 43.5v-39M6.69 24h34.62\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Clients : Icon
            {
                public Clients()
                    : base("Clients",
                            IconVariant.Regular,
                            IconSize.Size16,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M29.755 21.345A1 1 0 0 0 29 21h-2v-2c0-1.102-.897-2-2-2h-4c-1.103 0-2 .898-2 2v2h-2a1.001 1.001 0 0 0-.99 1.142l1 7A1 1 0 0 0 18 30h10a1 1 0 0 0 .99-.858l1-7a1.001 1.001 0 0 0-.235-.797M21 19h4v2h-4zm6.133 9h-8.266l-.714-5h9.694zM10 20h2v10h-2z\" />\r\n\t<path fill=\"#444791\" d=\"m16.78 17.875l-1.906-2.384l-1.442-3.605A2.986 2.986 0 0 0 10.646 10H5c-1.654 0-3 1.346-3 3v7c0 1.103.897 2 2 2h1v8h2V20H4v-7a1 1 0 0 1 1-1h5.646c.411 0 .776.247.928.629l1.645 3.996l2 2.5zM4 5c0-2.206 1.794-4 4-4s4 1.794 4 4s-1.794 4-4 4s-4-1.794-4-4m2 0c0 1.103.897 2 2 2s2-.897 2-2s-.897-2-2-2s-2 .897-2 2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Emails : Icon
            {
                public Emails()
                    : base("Emails",
                            IconVariant.Regular,
                            IconSize.Size16,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                          )
                {
                }
            }
        }
        [ExcludeFromCodeCoverage]
        public static class Size20
        {
            public class Auth : Icon
            {
                public Auth()
                    : base("Auth",
                            IconVariant.Regular,
                            IconSize.Size20,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472L29.01 41.21l-.732 1.29l-5-2.515l-4.047-14.158\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472c-6.605.37-12.467-3.46-11.261-11.166\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M9.675 19.277a7.41 7.41 0 1 1 11.133-5.334\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m29.337 19.411l12.554 11.947l.05 2.497l-5.634.03l-10.95-10.738m-.013.005a7.112 7.112 0 0 1-9.601-6.661h0a7.11 7.11 0 0 1 7.11-7.111h0a7.11 7.11 0 0 1 7.112 7.11h0a7.1 7.1 0 0 1-.623 2.91\" />\r\n</svg>"
                          )
                {
                }
            }
            public class People : Icon
            {
                public People()
                    : base("People",
                            IconVariant.Regular,
                            IconSize.Size20,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 15 15\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 14.49v.5h.5v-.5zm-10 0H0v.5h.5zm14 .01v.5h.5v-.5zM8 3.498a2.499 2.499 0 0 1-2.5 2.498v1C7.433 6.996 9 5.43 9 3.498zM5.5 5.996A2.499 2.499 0 0 1 3 3.498H2a3.499 3.499 0 0 0 3.5 3.498zM3 3.498A2.499 2.499 0 0 1 5.5 1V0A3.499 3.499 0 0 0 2 3.498zM5.5 1A2.5 2.5 0 0 1 8 3.498h1A3.499 3.499 0 0 0 5.5 0zm5 12.99H.5v1h10zm-9.5.5v-1.995H0v1.995zm2.5-4.496h4v-1h-4zm6.5 2.5v1.996h1v-1.996zm-2.5-2.5a2.5 2.5 0 0 1 2.5 2.5h1a3.5 3.5 0 0 0-3.5-3.5zm-6.5 2.5a2.5 2.5 0 0 1 2.5-2.5v-1a3.5 3.5 0 0 0-3.5 3.5zM14 13v1.5h1V13zm.5 1H12v1h2.5zM12 11a2 2 0 0 1 2 2h1a3 3 0 0 0-3-3zm-.5-3A1.5 1.5 0 0 1 10 6.5H9A2.5 2.5 0 0 0 11.5 9zM13 6.5A1.5 1.5 0 0 1 11.5 8v1A2.5 2.5 0 0 0 14 6.5zM11.5 5A1.5 1.5 0 0 1 13 6.5h1A2.5 2.5 0 0 0 11.5 4zm0-1A2.5 2.5 0 0 0 9 6.5h1A1.5 1.5 0 0 1 11.5 5z\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Users : Icon
            {
                public Users()
                    : base("Users",
                            IconVariant.Regular,
                            IconSize.Size20,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M11.5 6A3.514 3.514 0 0 0 8 9.5c0 1.922 1.578 3.5 3.5 3.5S15 11.422 15 9.5S13.422 6 11.5 6m9 0A3.514 3.514 0 0 0 17 9.5c0 1.922 1.578 3.5 3.5 3.5S24 11.422 24 9.5S22.422 6 20.5 6m-9 2c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5m9 0c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5M7 12c-2.2 0-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 2 23h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C10.523 18.117 11 17.114 11 16c0-2.2-1.8-4-4-4m5 11c-.625.836-1 1.887-1 3h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.024 5.024 0 0 0-1-3c-.34-.453-.75-.84-1.219-1.156C19.523 21.117 20 20.114 20 19c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.042 5.042 0 0 0 12 23m8 0h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C28.523 18.117 29 17.114 29 16c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 20 23M7 14c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m18 0c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m-9 3c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Permissions : Icon
            {
                public Permissions()
                    : base("Permissions",
                            IconVariant.Regular,
                            IconSize.Size20,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M22.2 4.86L6.69 11.25V27C6.69 35.44 24 43.5 24 43.5S41.31 35.44 41.31 27V11.25L25.8 4.86a4.68 4.68 0 0 0-3.6 0M24 43.5v-39M6.69 24h34.62\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Clients : Icon
            {
                public Clients()
                    : base("Clients",
                            IconVariant.Regular,
                            IconSize.Size20,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M29.755 21.345A1 1 0 0 0 29 21h-2v-2c0-1.102-.897-2-2-2h-4c-1.103 0-2 .898-2 2v2h-2a1.001 1.001 0 0 0-.99 1.142l1 7A1 1 0 0 0 18 30h10a1 1 0 0 0 .99-.858l1-7a1.001 1.001 0 0 0-.235-.797M21 19h4v2h-4zm6.133 9h-8.266l-.714-5h9.694zM10 20h2v10h-2z\" />\r\n\t<path fill=\"#444791\" d=\"m16.78 17.875l-1.906-2.384l-1.442-3.605A2.986 2.986 0 0 0 10.646 10H5c-1.654 0-3 1.346-3 3v7c0 1.103.897 2 2 2h1v8h2V20H4v-7a1 1 0 0 1 1-1h5.646c.411 0 .776.247.928.629l1.645 3.996l2 2.5zM4 5c0-2.206 1.794-4 4-4s4 1.794 4 4s-1.794 4-4 4s-4-1.794-4-4m2 0c0 1.103.897 2 2 2s2-.897 2-2s-.897-2-2-2s-2 .897-2 2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Emails : Icon
            {
                public Emails()
                    : base("Emails",
                            IconVariant.Regular,
                            IconSize.Size20,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                          )
                {
                }
            }
        }
        [ExcludeFromCodeCoverage]
        public static class Size24
        {
            public class Auth : Icon
            {
                public Auth()
                    : base("Auth",
                            IconVariant.Regular,
                            IconSize.Size24,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472L29.01 41.21l-.732 1.29l-5-2.515l-4.047-14.158\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472c-6.605.37-12.467-3.46-11.261-11.166\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M9.675 19.277a7.41 7.41 0 1 1 11.133-5.334\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m29.337 19.411l12.554 11.947l.05 2.497l-5.634.03l-10.95-10.738m-.013.005a7.112 7.112 0 0 1-9.601-6.661h0a7.11 7.11 0 0 1 7.11-7.111h0a7.11 7.11 0 0 1 7.112 7.11h0a7.1 7.1 0 0 1-.623 2.91\" />\r\n</svg>"
                          )
                {
                }
            }
            public class People : Icon
            {
                public People()
                    : base("People",
                            IconVariant.Regular,
                            IconSize.Size24,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 512 512\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"32\" d=\"M402 168c-2.93 40.67-33.1 72-66 72s-63.12-31.32-66-72c-3-42.31 26.37-72 66-72s69 30.46 66 72\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-miterlimit=\"10\" stroke-width=\"32\" d=\"M336 304c-65.17 0-127.84 32.37-143.54 95.41c-2.08 8.34 3.15 16.59 11.72 16.59h263.65c8.57 0 13.77-8.25 11.72-16.59C463.85 335.36 401.18 304 336 304Z\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"32\" d=\"M200 185.94c-2.34 32.48-26.72 58.06-53 58.06s-50.7-25.57-53-58.06C91.61 152.15 115.34 128 147 128s55.39 24.77 53 57.94\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-miterlimit=\"10\" stroke-width=\"32\" d=\"M206 306c-18.05-8.27-37.93-11.45-59-11.45c-52 0-102.1 25.85-114.65 76.2c-1.65 6.66 2.53 13.25 9.37 13.25H154\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Users : Icon
            {
                public Users()
                    : base("Users",
                            IconVariant.Regular,
                            IconSize.Size24,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M11.5 6A3.514 3.514 0 0 0 8 9.5c0 1.922 1.578 3.5 3.5 3.5S15 11.422 15 9.5S13.422 6 11.5 6m9 0A3.514 3.514 0 0 0 17 9.5c0 1.922 1.578 3.5 3.5 3.5S24 11.422 24 9.5S22.422 6 20.5 6m-9 2c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5m9 0c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5M7 12c-2.2 0-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 2 23h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C10.523 18.117 11 17.114 11 16c0-2.2-1.8-4-4-4m5 11c-.625.836-1 1.887-1 3h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.024 5.024 0 0 0-1-3c-.34-.453-.75-.84-1.219-1.156C19.523 21.117 20 20.114 20 19c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.042 5.042 0 0 0 12 23m8 0h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C28.523 18.117 29 17.114 29 16c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 20 23M7 14c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m18 0c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m-9 3c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Roles : Icon
            {
                public Roles()
                    : base("Roles",
                            IconVariant.Regular,
                            IconSize.Size24,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M19.307 3.21a2.91 2.91 0 1 0-.223 1.94a11.636 11.636 0 0 1 8.232 7.049l1.775-.698a13.576 13.576 0 0 0-9.784-8.291m-2.822 1.638a.97.97 0 1 1 0-1.939a.97.97 0 0 1 0 1.94m-4.267.805l-.717-1.774a13.576 13.576 0 0 0-8.291 9.784a2.91 2.91 0 1 0 1.94.223a11.636 11.636 0 0 1 7.068-8.233m-8.34 11.802a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94m12.607 8.727a2.91 2.91 0 0 0-2.599 1.62a11.636 11.636 0 0 1-8.233-7.05l-1.774.717a13.576 13.576 0 0 0 9.813 8.291a2.91 2.91 0 1 0 2.793-3.578m0 3.879a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94M32 16.485a2.91 2.91 0 1 0-4.199 2.599a11.636 11.636 0 0 1-7.05 8.232l.718 1.775a13.576 13.576 0 0 0 8.291-9.813A2.91 2.91 0 0 0 32 16.485m-2.91.97a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94\" />\r\n\t<path fill=\"#444791\" d=\"M19.19 16.35a3.879 3.879 0 1 0-5.42 0a4.848 4.848 0 0 0-2.134 4.014v1.939h9.697v-1.94a4.848 4.848 0 0 0-2.143-4.014m-4.645-2.774a1.94 1.94 0 1 1 3.88 0a1.94 1.94 0 0 1-3.88 0m-.97 6.788a2.91 2.91 0 1 1 5.819 0z\" class=\"ouiIcon__fillSecondary\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Permissions : Icon
            {
                public Permissions()
                    : base("Permissions",
                            IconVariant.Regular,
                            IconSize.Size24,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M22.2 4.86L6.69 11.25V27C6.69 35.44 24 43.5 24 43.5S41.31 35.44 41.31 27V11.25L25.8 4.86a4.68 4.68 0 0 0-3.6 0M24 43.5v-39M6.69 24h34.62\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Clients : Icon
            {
                public Clients()
                    : base("Clients",
                            IconVariant.Regular,
                            IconSize.Size24,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M29.755 21.345A1 1 0 0 0 29 21h-2v-2c0-1.102-.897-2-2-2h-4c-1.103 0-2 .898-2 2v2h-2a1.001 1.001 0 0 0-.99 1.142l1 7A1 1 0 0 0 18 30h10a1 1 0 0 0 .99-.858l1-7a1.001 1.001 0 0 0-.235-.797M21 19h4v2h-4zm6.133 9h-8.266l-.714-5h9.694zM10 20h2v10h-2z\" />\r\n\t<path fill=\"#444791\" d=\"m16.78 17.875l-1.906-2.384l-1.442-3.605A2.986 2.986 0 0 0 10.646 10H5c-1.654 0-3 1.346-3 3v7c0 1.103.897 2 2 2h1v8h2V20H4v-7a1 1 0 0 1 1-1h5.646c.411 0 .776.247.928.629l1.645 3.996l2 2.5zM4 5c0-2.206 1.794-4 4-4s4 1.794 4 4s-1.794 4-4 4s-4-1.794-4-4m2 0c0 1.103.897 2 2 2s2-.897 2-2s-.897-2-2-2s-2 .897-2 2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Emails : Icon
            {
                public Emails()
                    : base("Emails",
                            IconVariant.Regular,
                            IconSize.Size24,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                          )
                {
                }
            }
        }
        [ExcludeFromCodeCoverage]
        public static class Size28
        {
            public class Auth : Icon
            {
                public Auth()
                    : base("Auth",
                            IconVariant.Regular,
                            IconSize.Size28,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472L29.01 41.21l-.732 1.29l-5-2.515l-4.047-14.158\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472c-6.605.37-12.467-3.46-11.261-11.166\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M9.675 19.277a7.41 7.41 0 1 1 11.133-5.334\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m29.337 19.411l12.554 11.947l.05 2.497l-5.634.03l-10.95-10.738m-.013.005a7.112 7.112 0 0 1-9.601-6.661h0a7.11 7.11 0 0 1 7.11-7.111h0a7.11 7.11 0 0 1 7.112 7.11h0a7.1 7.1 0 0 1-.623 2.91\" />\r\n</svg>"
                          )
                {
                }
            }
            public class People : Icon
            {
                public People()
                    : base("People",
                            IconVariant.Regular,
                            IconSize.Size28,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 15 15\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 14.49v.5h.5v-.5zm-10 0H0v.5h.5zm14 .01v.5h.5v-.5zM8 3.498a2.499 2.499 0 0 1-2.5 2.498v1C7.433 6.996 9 5.43 9 3.498zM5.5 5.996A2.499 2.499 0 0 1 3 3.498H2a3.499 3.499 0 0 0 3.5 3.498zM3 3.498A2.499 2.499 0 0 1 5.5 1V0A3.499 3.499 0 0 0 2 3.498zM5.5 1A2.5 2.5 0 0 1 8 3.498h1A3.499 3.499 0 0 0 5.5 0zm5 12.99H.5v1h10zm-9.5.5v-1.995H0v1.995zm2.5-4.496h4v-1h-4zm6.5 2.5v1.996h1v-1.996zm-2.5-2.5a2.5 2.5 0 0 1 2.5 2.5h1a3.5 3.5 0 0 0-3.5-3.5zm-6.5 2.5a2.5 2.5 0 0 1 2.5-2.5v-1a3.5 3.5 0 0 0-3.5 3.5zM14 13v1.5h1V13zm.5 1H12v1h2.5zM12 11a2 2 0 0 1 2 2h1a3 3 0 0 0-3-3zm-.5-3A1.5 1.5 0 0 1 10 6.5H9A2.5 2.5 0 0 0 11.5 9zM13 6.5A1.5 1.5 0 0 1 11.5 8v1A2.5 2.5 0 0 0 14 6.5zM11.5 5A1.5 1.5 0 0 1 13 6.5h1A2.5 2.5 0 0 0 11.5 4zm0-1A2.5 2.5 0 0 0 9 6.5h1A1.5 1.5 0 0 1 11.5 5z\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Users : Icon
            {
                public Users()
                    : base("Users",
                            IconVariant.Regular,
                            IconSize.Size28,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M11.5 6A3.514 3.514 0 0 0 8 9.5c0 1.922 1.578 3.5 3.5 3.5S15 11.422 15 9.5S13.422 6 11.5 6m9 0A3.514 3.514 0 0 0 17 9.5c0 1.922 1.578 3.5 3.5 3.5S24 11.422 24 9.5S22.422 6 20.5 6m-9 2c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5m9 0c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5M7 12c-2.2 0-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 2 23h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C10.523 18.117 11 17.114 11 16c0-2.2-1.8-4-4-4m5 11c-.625.836-1 1.887-1 3h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.024 5.024 0 0 0-1-3c-.34-.453-.75-.84-1.219-1.156C19.523 21.117 20 20.114 20 19c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.042 5.042 0 0 0 12 23m8 0h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C28.523 18.117 29 17.114 29 16c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 20 23M7 14c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m18 0c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m-9 3c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Roles : Icon
            {
                public Roles()
                    : base("Roles",
                            IconVariant.Regular,
                            IconSize.Size28,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M19.307 3.21a2.91 2.91 0 1 0-.223 1.94a11.636 11.636 0 0 1 8.232 7.049l1.775-.698a13.576 13.576 0 0 0-9.784-8.291m-2.822 1.638a.97.97 0 1 1 0-1.939a.97.97 0 0 1 0 1.94m-4.267.805l-.717-1.774a13.576 13.576 0 0 0-8.291 9.784a2.91 2.91 0 1 0 1.94.223a11.636 11.636 0 0 1 7.068-8.233m-8.34 11.802a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94m12.607 8.727a2.91 2.91 0 0 0-2.599 1.62a11.636 11.636 0 0 1-8.233-7.05l-1.774.717a13.576 13.576 0 0 0 9.813 8.291a2.91 2.91 0 1 0 2.793-3.578m0 3.879a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94M32 16.485a2.91 2.91 0 1 0-4.199 2.599a11.636 11.636 0 0 1-7.05 8.232l.718 1.775a13.576 13.576 0 0 0 8.291-9.813A2.91 2.91 0 0 0 32 16.485m-2.91.97a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94\" />\r\n\t<path fill=\"#444791\" d=\"M19.19 16.35a3.879 3.879 0 1 0-5.42 0a4.848 4.848 0 0 0-2.134 4.014v1.939h9.697v-1.94a4.848 4.848 0 0 0-2.143-4.014m-4.645-2.774a1.94 1.94 0 1 1 3.88 0a1.94 1.94 0 0 1-3.88 0m-.97 6.788a2.91 2.91 0 1 1 5.819 0z\" class=\"ouiIcon__fillSecondary\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Permissions : Icon
            {
                public Permissions()
                    : base("Permissions",
                            IconVariant.Regular,
                            IconSize.Size28,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M22.2 4.86L6.69 11.25V27C6.69 35.44 24 43.5 24 43.5S41.31 35.44 41.31 27V11.25L25.8 4.86a4.68 4.68 0 0 0-3.6 0M24 43.5v-39M6.69 24h34.62\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Clients : Icon
            {
                public Clients()
                    : base("Clients",
                            IconVariant.Regular,
                            IconSize.Size28,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M29.755 21.345A1 1 0 0 0 29 21h-2v-2c0-1.102-.897-2-2-2h-4c-1.103 0-2 .898-2 2v2h-2a1.001 1.001 0 0 0-.99 1.142l1 7A1 1 0 0 0 18 30h10a1 1 0 0 0 .99-.858l1-7a1.001 1.001 0 0 0-.235-.797M21 19h4v2h-4zm6.133 9h-8.266l-.714-5h9.694zM10 20h2v10h-2z\" />\r\n\t<path fill=\"#444791\" d=\"m16.78 17.875l-1.906-2.384l-1.442-3.605A2.986 2.986 0 0 0 10.646 10H5c-1.654 0-3 1.346-3 3v7c0 1.103.897 2 2 2h1v8h2V20H4v-7a1 1 0 0 1 1-1h5.646c.411 0 .776.247.928.629l1.645 3.996l2 2.5zM4 5c0-2.206 1.794-4 4-4s4 1.794 4 4s-1.794 4-4 4s-4-1.794-4-4m2 0c0 1.103.897 2 2 2s2-.897 2-2s-.897-2-2-2s-2 .897-2 2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Emails : Icon
            {
                public Emails()
                    : base("Emails",
                            IconVariant.Regular,
                            IconSize.Size28,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                          )
                {
                }
            }
        }
        [ExcludeFromCodeCoverage]
        public static class Size32
        {
            public class Auth : Icon
            {
                public Auth()
                    : base("Auth",
                            IconVariant.Regular,
                            IconSize.Size32,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472L29.01 41.21l-.732 1.29l-5-2.515l-4.047-14.158\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472c-6.605.37-12.467-3.46-11.261-11.166\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M9.675 19.277a7.41 7.41 0 1 1 11.133-5.334\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m29.337 19.411l12.554 11.947l.05 2.497l-5.634.03l-10.95-10.738m-.013.005a7.112 7.112 0 0 1-9.601-6.661h0a7.11 7.11 0 0 1 7.11-7.111h0a7.11 7.11 0 0 1 7.112 7.11h0a7.1 7.1 0 0 1-.623 2.91\" />\r\n</svg>"
                          )
                {
                }
            }
            public class People : Icon
            {
                public People()
                    : base("People",
                            IconVariant.Regular,
                            IconSize.Size32,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 15 15\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 14.49v.5h.5v-.5zm-10 0H0v.5h.5zm14 .01v.5h.5v-.5zM8 3.498a2.499 2.499 0 0 1-2.5 2.498v1C7.433 6.996 9 5.43 9 3.498zM5.5 5.996A2.499 2.499 0 0 1 3 3.498H2a3.499 3.499 0 0 0 3.5 3.498zM3 3.498A2.499 2.499 0 0 1 5.5 1V0A3.499 3.499 0 0 0 2 3.498zM5.5 1A2.5 2.5 0 0 1 8 3.498h1A3.499 3.499 0 0 0 5.5 0zm5 12.99H.5v1h10zm-9.5.5v-1.995H0v1.995zm2.5-4.496h4v-1h-4zm6.5 2.5v1.996h1v-1.996zm-2.5-2.5a2.5 2.5 0 0 1 2.5 2.5h1a3.5 3.5 0 0 0-3.5-3.5zm-6.5 2.5a2.5 2.5 0 0 1 2.5-2.5v-1a3.5 3.5 0 0 0-3.5 3.5zM14 13v1.5h1V13zm.5 1H12v1h2.5zM12 11a2 2 0 0 1 2 2h1a3 3 0 0 0-3-3zm-.5-3A1.5 1.5 0 0 1 10 6.5H9A2.5 2.5 0 0 0 11.5 9zM13 6.5A1.5 1.5 0 0 1 11.5 8v1A2.5 2.5 0 0 0 14 6.5zM11.5 5A1.5 1.5 0 0 1 13 6.5h1A2.5 2.5 0 0 0 11.5 4zm0-1A2.5 2.5 0 0 0 9 6.5h1A1.5 1.5 0 0 1 11.5 5z\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Users : Icon
            {
                public Users()
                    : base("Users",
                            IconVariant.Regular,
                            IconSize.Size32,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M11.5 6A3.514 3.514 0 0 0 8 9.5c0 1.922 1.578 3.5 3.5 3.5S15 11.422 15 9.5S13.422 6 11.5 6m9 0A3.514 3.514 0 0 0 17 9.5c0 1.922 1.578 3.5 3.5 3.5S24 11.422 24 9.5S22.422 6 20.5 6m-9 2c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5m9 0c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5M7 12c-2.2 0-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 2 23h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C10.523 18.117 11 17.114 11 16c0-2.2-1.8-4-4-4m5 11c-.625.836-1 1.887-1 3h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.024 5.024 0 0 0-1-3c-.34-.453-.75-.84-1.219-1.156C19.523 21.117 20 20.114 20 19c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.042 5.042 0 0 0 12 23m8 0h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C28.523 18.117 29 17.114 29 16c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 20 23M7 14c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m18 0c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m-9 3c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Roles : Icon
            {
                public Roles()
                    : base("Roles",
                            IconVariant.Regular,
                            IconSize.Size32,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M19.307 3.21a2.91 2.91 0 1 0-.223 1.94a11.636 11.636 0 0 1 8.232 7.049l1.775-.698a13.576 13.576 0 0 0-9.784-8.291m-2.822 1.638a.97.97 0 1 1 0-1.939a.97.97 0 0 1 0 1.94m-4.267.805l-.717-1.774a13.576 13.576 0 0 0-8.291 9.784a2.91 2.91 0 1 0 1.94.223a11.636 11.636 0 0 1 7.068-8.233m-8.34 11.802a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94m12.607 8.727a2.91 2.91 0 0 0-2.599 1.62a11.636 11.636 0 0 1-8.233-7.05l-1.774.717a13.576 13.576 0 0 0 9.813 8.291a2.91 2.91 0 1 0 2.793-3.578m0 3.879a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94M32 16.485a2.91 2.91 0 1 0-4.199 2.599a11.636 11.636 0 0 1-7.05 8.232l.718 1.775a13.576 13.576 0 0 0 8.291-9.813A2.91 2.91 0 0 0 32 16.485m-2.91.97a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94\" />\r\n\t<path fill=\"#444791\" d=\"M19.19 16.35a3.879 3.879 0 1 0-5.42 0a4.848 4.848 0 0 0-2.134 4.014v1.939h9.697v-1.94a4.848 4.848 0 0 0-2.143-4.014m-4.645-2.774a1.94 1.94 0 1 1 3.88 0a1.94 1.94 0 0 1-3.88 0m-.97 6.788a2.91 2.91 0 1 1 5.819 0z\" class=\"ouiIcon__fillSecondary\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Permissions : Icon
            {
                public Permissions()
                    : base("Permissions",
                            IconVariant.Regular,
                            IconSize.Size32,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M22.2 4.86L6.69 11.25V27C6.69 35.44 24 43.5 24 43.5S41.31 35.44 41.31 27V11.25L25.8 4.86a4.68 4.68 0 0 0-3.6 0M24 43.5v-39M6.69 24h34.62\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Clients : Icon
            {
                public Clients()
                    : base("Clients",
                            IconVariant.Regular,
                            IconSize.Size32,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M29.755 21.345A1 1 0 0 0 29 21h-2v-2c0-1.102-.897-2-2-2h-4c-1.103 0-2 .898-2 2v2h-2a1.001 1.001 0 0 0-.99 1.142l1 7A1 1 0 0 0 18 30h10a1 1 0 0 0 .99-.858l1-7a1.001 1.001 0 0 0-.235-.797M21 19h4v2h-4zm6.133 9h-8.266l-.714-5h9.694zM10 20h2v10h-2z\" />\r\n\t<path fill=\"#444791\" d=\"m16.78 17.875l-1.906-2.384l-1.442-3.605A2.986 2.986 0 0 0 10.646 10H5c-1.654 0-3 1.346-3 3v7c0 1.103.897 2 2 2h1v8h2V20H4v-7a1 1 0 0 1 1-1h5.646c.411 0 .776.247.928.629l1.645 3.996l2 2.5zM4 5c0-2.206 1.794-4 4-4s4 1.794 4 4s-1.794 4-4 4s-4-1.794-4-4m2 0c0 1.103.897 2 2 2s2-.897 2-2s-.897-2-2-2s-2 .897-2 2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Emails : Icon
            {
                public Emails()
                    : base("Emails",
                            IconVariant.Regular,
                            IconSize.Size32,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                          )
                {
                }
            }
        }
        [ExcludeFromCodeCoverage]
        public static class Size48
        {
            public class Auth : Icon
            {
                public Auth()
                    : base("Auth",
                            IconVariant.Regular,
                            IconSize.Size48,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472L29.01 41.21l-.732 1.29l-5-2.515l-4.047-14.158\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M24.393 26.472c-6.605.37-12.467-3.46-11.261-11.166\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M9.675 19.277a7.41 7.41 0 1 1 11.133-5.334\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m29.337 19.411l12.554 11.947l.05 2.497l-5.634.03l-10.95-10.738m-.013.005a7.112 7.112 0 0 1-9.601-6.661h0a7.11 7.11 0 0 1 7.11-7.111h0a7.11 7.11 0 0 1 7.112 7.11h0a7.1 7.1 0 0 1-.623 2.91\" />\r\n</svg>"
                          )
                {
                }
            }
            public class People : Icon
            {
                public People()
                    : base("People",
                            IconVariant.Regular,
                            IconSize.Size48,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 15 15\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 14.49v.5h.5v-.5zm-10 0H0v.5h.5zm14 .01v.5h.5v-.5zM8 3.498a2.499 2.499 0 0 1-2.5 2.498v1C7.433 6.996 9 5.43 9 3.498zM5.5 5.996A2.499 2.499 0 0 1 3 3.498H2a3.499 3.499 0 0 0 3.5 3.498zM3 3.498A2.499 2.499 0 0 1 5.5 1V0A3.499 3.499 0 0 0 2 3.498zM5.5 1A2.5 2.5 0 0 1 8 3.498h1A3.499 3.499 0 0 0 5.5 0zm5 12.99H.5v1h10zm-9.5.5v-1.995H0v1.995zm2.5-4.496h4v-1h-4zm6.5 2.5v1.996h1v-1.996zm-2.5-2.5a2.5 2.5 0 0 1 2.5 2.5h1a3.5 3.5 0 0 0-3.5-3.5zm-6.5 2.5a2.5 2.5 0 0 1 2.5-2.5v-1a3.5 3.5 0 0 0-3.5 3.5zM14 13v1.5h1V13zm.5 1H12v1h2.5zM12 11a2 2 0 0 1 2 2h1a3 3 0 0 0-3-3zm-.5-3A1.5 1.5 0 0 1 10 6.5H9A2.5 2.5 0 0 0 11.5 9zM13 6.5A1.5 1.5 0 0 1 11.5 8v1A2.5 2.5 0 0 0 14 6.5zM11.5 5A1.5 1.5 0 0 1 13 6.5h1A2.5 2.5 0 0 0 11.5 4zm0-1A2.5 2.5 0 0 0 9 6.5h1A1.5 1.5 0 0 1 11.5 5z\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Users : Icon
            {
                public Users()
                    : base("Users",
                            IconVariant.Regular,
                            IconSize.Size48,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M11.5 6A3.514 3.514 0 0 0 8 9.5c0 1.922 1.578 3.5 3.5 3.5S15 11.422 15 9.5S13.422 6 11.5 6m9 0A3.514 3.514 0 0 0 17 9.5c0 1.922 1.578 3.5 3.5 3.5S24 11.422 24 9.5S22.422 6 20.5 6m-9 2c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5m9 0c.84 0 1.5.66 1.5 1.5s-.66 1.5-1.5 1.5s-1.5-.66-1.5-1.5s.66-1.5 1.5-1.5M7 12c-2.2 0-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 2 23h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C10.523 18.117 11 17.114 11 16c0-2.2-1.8-4-4-4m5 11c-.625.836-1 1.887-1 3h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.024 5.024 0 0 0-1-3c-.34-.453-.75-.84-1.219-1.156C19.523 21.117 20 20.114 20 19c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.042 5.042 0 0 0 12 23m8 0h2c0-1.668 1.332-3 3-3s3 1.332 3 3h2a5.036 5.036 0 0 0-2.219-4.156C28.523 18.117 29 17.114 29 16c0-2.2-1.8-4-4-4s-4 1.8-4 4c0 1.113.477 2.117 1.219 2.844A5.036 5.036 0 0 0 20 23M7 14c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m18 0c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2m-9 3c1.117 0 2 .883 2 2s-.883 2-2 2s-2-.883-2-2s.883-2 2-2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Roles : Icon
            {
                public Roles()
                    : base("Roles",
                            IconVariant.Regular,
                            IconSize.Size48,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M19.307 3.21a2.91 2.91 0 1 0-.223 1.94a11.636 11.636 0 0 1 8.232 7.049l1.775-.698a13.576 13.576 0 0 0-9.784-8.291m-2.822 1.638a.97.97 0 1 1 0-1.939a.97.97 0 0 1 0 1.94m-4.267.805l-.717-1.774a13.576 13.576 0 0 0-8.291 9.784a2.91 2.91 0 1 0 1.94.223a11.636 11.636 0 0 1 7.068-8.233m-8.34 11.802a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94m12.607 8.727a2.91 2.91 0 0 0-2.599 1.62a11.636 11.636 0 0 1-8.233-7.05l-1.774.717a13.576 13.576 0 0 0 9.813 8.291a2.91 2.91 0 1 0 2.793-3.578m0 3.879a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94M32 16.485a2.91 2.91 0 1 0-4.199 2.599a11.636 11.636 0 0 1-7.05 8.232l.718 1.775a13.576 13.576 0 0 0 8.291-9.813A2.91 2.91 0 0 0 32 16.485m-2.91.97a.97.97 0 1 1 0-1.94a.97.97 0 0 1 0 1.94\" />\r\n\t<path fill=\"#444791\" d=\"M19.19 16.35a3.879 3.879 0 1 0-5.42 0a4.848 4.848 0 0 0-2.134 4.014v1.939h9.697v-1.94a4.848 4.848 0 0 0-2.143-4.014m-4.645-2.774a1.94 1.94 0 1 1 3.88 0a1.94 1.94 0 0 1-3.88 0m-.97 6.788a2.91 2.91 0 1 1 5.819 0z\" class=\"ouiIcon__fillSecondary\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Permissions : Icon
            {
                public Permissions()
                    : base("Permissions",
                            IconVariant.Regular,
                            IconSize.Size48,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M22.2 4.86L6.69 11.25V27C6.69 35.44 24 43.5 24 43.5S41.31 35.44 41.31 27V11.25L25.8 4.86a4.68 4.68 0 0 0-3.6 0M24 43.5v-39M6.69 24h34.62\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Clients : Icon
            {
                public Clients()
                    : base("Clients",
                            IconVariant.Regular,
                            IconSize.Size48,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M29.755 21.345A1 1 0 0 0 29 21h-2v-2c0-1.102-.897-2-2-2h-4c-1.103 0-2 .898-2 2v2h-2a1.001 1.001 0 0 0-.99 1.142l1 7A1 1 0 0 0 18 30h10a1 1 0 0 0 .99-.858l1-7a1.001 1.001 0 0 0-.235-.797M21 19h4v2h-4zm6.133 9h-8.266l-.714-5h9.694zM10 20h2v10h-2z\" />\r\n\t<path fill=\"#444791\" d=\"m16.78 17.875l-1.906-2.384l-1.442-3.605A2.986 2.986 0 0 0 10.646 10H5c-1.654 0-3 1.346-3 3v7c0 1.103.897 2 2 2h1v8h2V20H4v-7a1 1 0 0 1 1-1h5.646c.411 0 .776.247.928.629l1.645 3.996l2 2.5zM4 5c0-2.206 1.794-4 4-4s4 1.794 4 4s-1.794 4-4 4s-4-1.794-4-4m2 0c0 1.103.897 2 2 2s2-.897 2-2s-.897-2-2-2s-2 .897-2 2\" />\r\n</svg>"
                          )
                {
                }
            }
            public class Emails : Icon
            {
                public Emails()
                    : base("Emails",
                            IconVariant.Regular,
                            IconSize.Size48,
                            "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                          )
                {
                }
            }
        }
    }
}
