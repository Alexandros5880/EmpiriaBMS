using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Fast.Components.FluentUI;

// Icons Color: #444791

public static class MyIcons
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
        public class Projects1 : Icon
        {
            public Projects1()
                : base("Projects1",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Projects2 : Icon
        {
            public Projects2()
                : base("Projects2",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 256 256\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M88 144v-16a8 8 0 0 1 16 0v16a8 8 0 0 1-16 0m40 8a8 8 0 0 0 8-8v-24a8 8 0 0 0-16 0v24a8 8 0 0 0 8 8m32 0a8 8 0 0 0 8-8v-32a8 8 0 0 0-16 0v32a8 8 0 0 0 8 8m56-72v96h8a8 8 0 0 1 0 16h-88v17.38a24 24 0 1 1-16 0V192H32a8 8 0 0 1 0-16h8V80a16 16 0 0 1-16-16V48a16 16 0 0 1 16-16h176a16 16 0 0 1 16 16v16a16 16 0 0 1-16 16m-80 152a8 8 0 1 0-8 8a8 8 0 0 0 8-8M40 64h176V48H40Zm160 16H56v96h144Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Stages : Icon
        {
            public Stages()
                : base("Stages",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Categories : Icon
        {
            public Categories()
                : base("Categories",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m6.76 6l.45.89L7.76 8H12v5H4V6zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8V6zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55M6.76 19l.45.89l.55 1.11H12v5H4v-7zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8v-7zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SubCategories : Icon
        {
            public SubCategories()
                : base("SubCategories",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M20 26h6v2h-6zm0-8h8v2h-8zm0-8h10v2H20zm-5-6h2v24h-2zm-4.414-.041L7 7.249L3.412 3.958L2 5.373L7 10l5-4.627z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Issues : Icon
        {
            public Issues()
                : base("Issues",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 1024 1024\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M464 688a48 48 0 1 0 96 0a48 48 0 1 0-96 0m72-112c4.4 0 8-3.6 8-8V296c0-4.4-3.6-8-8-8h-48c-4.4 0-8 3.6-8 8v272c0 4.4 3.6 8 8 8zm400-188h-59.3c-2.6 0-5 1.2-6.5 3.3L763.7 538.1l-49.9-68.8a7.92 7.92 0 0 0-6.5-3.3H648c-6.5 0-10.3 7.4-6.5 12.7l109.2 150.7a16.1 16.1 0 0 0 26 0l165.8-228.7c3.8-5.3 0-12.7-6.5-12.7m-44 306h-64.2c-5.5 0-10.6 2.9-13.6 7.5a352.2 352.2 0 0 1-49.8 62.2A355.9 355.9 0 0 1 651.1 840a355 355 0 0 1-138.7 27.9c-48.1 0-94.8-9.4-138.7-27.9a355.9 355.9 0 0 1-113.3-76.3A353.1 353.1 0 0 1 184 650.5c-18.6-43.8-28-90.5-28-138.5s9.4-94.7 28-138.5c17.9-42.4 43.6-80.5 76.4-113.2s70.9-58.4 113.3-76.3a355 355 0 0 1 138.7-27.9c48.1 0 94.8 9.4 138.7 27.9c42.4 17.9 80.5 43.6 113.3 76.3c19 19 35.6 39.8 49.8 62.2c2.9 4.7 8.1 7.5 13.6 7.5H892c6 0 9.8-6.3 7.2-11.6C828.8 178.5 684.7 82 517.7 80C278.9 77.2 80.5 272.5 80 511.2C79.5 750.1 273.3 944 512.4 944c169.2 0 315.6-97 386.7-238.4A8 8 0 0 0 892 694\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers1 : Icon
        {
            public Offers1()
                : base("Offers1",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M21 13c.6 0 1.1.2 1.4.6c.4.4.6.9.6 1.4l-8 3l-7-2V7h1.9l7.3 2.7c.5.2.8.6.8 1.1c0 .3-.1.6-.3.8s-.5.4-.9.4H14l-1.7-.7l-.3.9l2 .8zM2 7h4v11H2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers2 : Icon
        {
            public Offers2()
                : base("Offers2",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m20.749 12l1.104-1.908a1 1 0 0 0-.365-1.366l-1.91-1.104v-2.2a1 1 0 0 0-1-1h-2.199l-1.103-1.909a1.008 1.008 0 0 0-.607-.466a.993.993 0 0 0-.759.1L12 3.251l-1.91-1.105a1 1 0 0 0-1.366.366L7.62 4.422H5.421a1 1 0 0 0-1 1v2.199l-1.91 1.104a.998.998 0 0 0-.365 1.367L3.25 12l-1.104 1.908a1.004 1.004 0 0 0 .364 1.367l1.91 1.104v2.199a1 1 0 0 0 1 1h2.2l1.104 1.91a1.01 1.01 0 0 0 .866.5c.174 0 .347-.046.501-.135l1.908-1.104l1.91 1.104a1.001 1.001 0 0 0 1.366-.365l1.103-1.91h2.199a1 1 0 0 0 1-1v-2.199l1.91-1.104a1 1 0 0 0 .365-1.367zM9.499 6.99a1.5 1.5 0 1 1-.001 3.001a1.5 1.5 0 0 1 .001-3.001m.3 9.6l-1.6-1.199l6-8l1.6 1.199zm4.7.4a1.5 1.5 0 1 1 .001-3.001a1.5 1.5 0 0 1-.001 3.001\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Types : Icon
        {
            public Types()
                : base("Types",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M22 17a5 5 0 1 1-10.001-.001A5 5 0 0 1 22 17M6.5 6.5h3.8L7 1L1 11h5.5zm9.5 4.085V8H8v8h2.585A6.505 6.505 0 0 1 16 10.585\" />\r\n</svg>"
                      )
            {
            }
        }
        public class States : Icon
        {
            public States()
                : base("States",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices1 : Icon
        {
            public Invoices1()
                : base("Invoices1",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M4.4 10.2c-.6.1-1.4-.3-1.7-.4l-.5.9s.9.4 1.7.5v.8h1v-.9c.9-.3 1.4-1.1 1.5-1.8c0-.8-.6-1.4-1.9-1.9c-.4-.2-1.1-.5-1.1-.9c0-.5.4-.8 1-.8c.7 0 1.4.3 1.4.3l.4-.9s-.5-.2-1.2-.4V4H4v.7c-.9.2-1.5.8-1.6 1.7c0 1.2 1.3 1.7 1.8 1.9c.6.2 1.3.6 1.3.9c0 .4-.4.9-1.1 1\" />\r\n\t<path fill=\"#444791\" d=\"M0 2v12h16V2zm15 11H1V3h14z\" />\r\n\t<path fill=\"#444791\" d=\"M8 5h6v1H8zm0 2h6v1H8zm0 2h3v1H8z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices2 : Icon
        {
            public Invoices2()
                : base("Invoices2",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M6 3v26h16v-2H8V5h10v6h6v2h2V9.6l-.3-.3l-6-6l-.3-.3zm14 3.4L22.6 9H20zM10 13v2h12v-2zm17 2v2c-1.7.3-3 1.7-3 3.5c0 2 1.5 3.5 3.5 3.5h1c.8 0 1.5.7 1.5 1.5s-.7 1.5-1.5 1.5H25v2h2v2h2v-2c1.7-.3 3-1.7 3-3.5c0-2-1.5-3.5-3.5-3.5h-1c-.8 0-1.5-.7-1.5-1.5s.7-1.5 1.5-1.5H31v-2h-2v-2zm-17 3v2h7v-2zm9 0v2h3v-2zm-9 4v2h7v-2zm9 0v2h3v-2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments1 : Icon
        {
            public Payments1()
                : base("Payments1",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m17.5 16.82l2.44 1.41l-.75 1.3L16 17.69V14h1.5zM24 17c0 3.87-3.13 7-7 7s-7-3.13-7-7c0-.34.03-.67.08-1H2V4h18v6.68c2.36 1.13 4 3.53 4 6.32m-13.32-3c.18-.36.37-.7.6-1.03c-.09.03-.18.03-.28.03c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3c0 .25-.04.5-.1.73c.94-.46 1.99-.73 3.1-.73c.34 0 .67.03 1 .08V8a2 2 0 0 1-2-2H6c0 1.11-.89 2-2 2v4a2 2 0 0 1 2 2zM22 17c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5s5-2.24 5-5\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments2 : Icon
        {
            public Payments2()
                : base("Payments2",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 10a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1zM1 5.5A2.5 2.5 0 0 1 3.5 3h9A2.5 2.5 0 0 1 15 5.5v5a2.5 2.5 0 0 1-2.5 2.5h-9A2.5 2.5 0 0 1 1 10.5zM14 6v-.5A1.5 1.5 0 0 0 12.5 4h-9A1.5 1.5 0 0 0 2 5.5V6zM2 7v3.5A1.5 1.5 0 0 0 3.5 12h9a1.5 1.5 0 0 0 1.5-1.5V7z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines1 : Icon
        {
            public Disciplines1()
                : base("Disciplines1",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\" d=\"M6 18h36v6a6 6 0 0 1-6 6H12a6 6 0 0 1-6-6zm34 24H8m5 0l3-12m19 12l-3-12m-2-12L27 4h-6l-3 14m18-7h4M8 11h4\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines2 : Icon
        {
            public Disciplines2()
                : base("Disciplines2",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<rect width=\"36\" height=\"20\" x=\"6\" y=\"6\" rx=\"2\" />\r\n\t\t<path stroke-linecap=\"round\" d=\"M14 13h8m-8 6h20M8 44l4.889-6h21.778L40 44M24 26v18\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables1 : Icon
        {
            public Deliverables1()
                : base("Deliverables1",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m23 1l-6 6l1.415 1.402L22 4.818V21H10V10H8v11c0 1.103.897 2 2 2h12c1.103 0 2-.897 2-2V4.815l3.586 3.587L29 7z\" />\r\n\t<path fill=\"#444791\" d=\"M18.5 19h-5c-.827 0-1.5-.673-1.5-1.5v-5c0-.827.673-1.5 1.5-1.5h5c.827 0 1.5.673 1.5 1.5v5c0 .827-.673 1.5-1.5 1.5M14 17h4v-4h-4zm2 14v-2c7.168 0 13-5.832 13-13c0-1.265-.181-2.514-.538-3.715l1.917-.57C30.79 13.1 31 14.542 31 16c0 8.271-6.729 15-15 15M1.621 20.285A15.011 15.011 0 0 1 1 16C1 7.729 7.729 1 16 1v2C8.832 3 3 8.832 3 16c0 1.265.181 2.515.538 3.715z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables2 : Icon
        {
            public Deliverables2()
                : base("Deliverables2",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<path d=\"m20 33l6 2s15-3 17-3s2 2 0 4s-9 8-15 8s-10-3-14-3H4\" />\r\n\t\t<path d=\"M4 29c2-2 6-5 10-5s13.5 4 15 6s-3 5-3 5M16 18v-8a2 2 0 0 1 2-2h24a2 2 0 0 1 2 2v16\" />\r\n\t\t<path d=\"M25 8h10v9H25z\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks1 : Icon
        {
            public SupportiveWorks1()
                : base("SupportiveWorks1",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-width=\"2\" d=\"M19 7s-5 7-12.5 7c-2 0-5.5 1-5.5 5v4h11v-4c0-2.5 3-1 7-8l-1.5-1.5M3 5V2h20v14h-3M11 1h4v2h-4zM6.5 14a3.5 3.5 0 1 0 0-7a3.5 3.5 0 0 0 0 7Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks2 : Icon
        {
            public SupportiveWorks2()
                : base("SupportiveWorks2",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M16 32C7.125 32 0 24.776 0 16C0 7.125 7.125 0 16 0s16 7.125 16 16c0 8.776-7.125 16-16 16m0-29.312c-7.328 0-13.318 5.984-13.318 13.313S8.672 29.319 16 29.319c7.328 0 13.318-5.99 13.318-13.318S23.328 2.688 16 2.688m7.849 14.859H12.286a.927.927 0 0 1-.932-.917v-1.349c0-.521.411-.932.932-.932h11.661c.516 0 .927.417.927.932v1.339c-.099.516-.516.927-1.026.927zm-2.995-5.162H9.187a.925.925 0 0 1-.932-.917v-1.349c0-.417.417-.828.932-.828h11.661c.417 0 .828.417.828.828v1.339c0 .516-.411.927-.823.927zm-11.666 7.23h11.667c.516 0 .927.411.927.927v1.339a.928.928 0 0 1-.922.932H9.188c-.516-.104-.927-.516-.927-1.031v-1.344c-.005-.411.411-.823.927-.823\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Documents : Icon
        {
            public Documents()
                : base("Documents",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M40.358 12.581L26.363 6.04a5.74 5.74 0 0 0-4.857-.001l-13.863 6.47a2.295 2.295 0 0 0-.001 4.159l13.995 6.541a5.74 5.74 0 0 0 4.857.002l13.863-6.471a2.295 2.295 0 0 0 .001-4.159\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m13.227 19.278l-5.584 2.606a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.002l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M13.227 28.654L7.643 31.26a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.001l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Download : Icon
        {
            public Download()
                : base("Download",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m12 16l-5-5l1.4-1.45l2.6 2.6V4h2v8.15l2.6-2.6L17 11zm-6 4q-.825 0-1.412-.587T4 18v-3h2v3h12v-3h2v3q0 .825-.587 1.413T18 20z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Contract : Icon
        {
            public Contract()
                : base("Contract",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 36 36\"><path fill=\"#444791\" d=\"M8 8.2h16v1.6H8zm0 8h8.086v1.6H8zm15.378-4H8v1.6h13.779zM12.794 29.072a2.47 2.47 0 0 0 2.194.824h7.804a.7.7 0 0 0 0-1.4h-7.804c-.911-.016-.749-.807-.621-1.052a3.962 3.962 0 0 0 .387-.915a1.183 1.183 0 0 0-.616-1.322a1.899 1.899 0 0 0-2.24.517c-.344.355-.822.898-1.28 1.426c.283-1.109.65-2.532 1.01-3.92a1.315 1.315 0 0 0-.755-1.626a1.425 1.425 0 0 0-1.775.793c-.432.831-3.852 6.562-3.886 6.62a.7.7 0 1 0 1.202.718c.128-.215 2.858-4.788 3.719-6.315c-.648 2.5-1.362 5.282-1.404 5.532a.869.869 0 0 0 .407.969a.92.92 0 0 0 1.106-.224c.126-.114.362-.385.957-1.076a62.093 62.093 0 0 1 1.703-1.921c.218-.23.35-.128.222.098a2.291 2.291 0 0 0-.33 2.274\"/><path fill=\"#444791\" d=\"M28 21.695V32H4V4h24v4.993l1.33-1.33a4.304 4.304 0 0 1 .67-.54V3a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v30a1 1 0 0 0 1 1h26a1 1 0 0 0 1-1V21.427a2.91 2.91 0 0 1-2 .268\"/><path fill=\"#444791\" d=\"m34.128 11.861l-.523-.523a1.898 1.898 0 0 0-.11-2.423a1.956 1.956 0 0 0-2.75.162L18.22 21.6l-.837 3.142a.234.234 0 0 0 .296.294l3.131-.847l11.692-11.692l.494.495a.371.371 0 0 1 0 .525l-4.917 4.917a.8.8 0 0 0 1.132 1.131l4.917-4.917a1.972 1.972 0 0 0 0-2.788\"/></svg>"
                      )
            {
            }
        }
        public class Result : Icon
        {
            public Result()
                : base("Result",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 2048 2048\"><path fill=\"#444791\" d=\"M1664 1792v-128H0v128zm384-1408V256h-128v128zm0 1024v-128h-128v128zm-384 0v-128H0v128zm0-1152H0v128h1664zm0 512V640H0v128z\"/></svg>"
                      )
            {
            }
        }
        public class Save : Icon
        {
            public Save()
                : base("Save",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 24 24\"><path fill=\"#444791\" d=\"M2 2h14.414L22 7.586V22H2zm2 2v16h2v-6h12v6h2V8.414L15.586 4H13v4H6V4zm4 0v2h3V4zm8 16v-4H8v4z\"/></svg>"
                      )
            {
            }
        }
        public class Expenses : Icon
        {
            public Expenses()
                : base("Expenses",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 48 48\"><g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m16.517 14.344l7.705-4.8l10.274 8.688v12.566l-5.967 4.836V23.817zm9.541-5.086L31.9 5.646l10.46 7.293l-6.433 4.926m.277 10.748l6.296-5.14m-6.296 2.479l6.296-5.14m-6.296 2.48l6.296-5.14m-6.296 2.48l6.296-5.14\"/><path d=\"m35.314 14.172l2.723-2.077l-1.865-1.247l-1.498 1.131M5.5 31.954l13.543 10.4l7.423-5.91\"/><path d=\"m5.5 29.285l13.543 10.4l7.423-5.91\"/><path d=\"m5.604 26.616l13.543 10.401l7.423-5.91\"/><path d=\"m5.59 23.948l13.542 10.4l7.423-5.91m-6.32-4.688c-.226 1.027-1.694 1.554-3.278 1.175h0c-1.584-.378-2.685-1.517-2.459-2.545c.226-1.027 1.694-1.553 3.278-1.175s2.685 1.518 2.459 2.545\"/><path d=\"m15.051 15.826l-9.295 5.595l13.331 10.117l7.64-6.015\"/></g></svg>"
                      )
            {
            }
        }
        public class Close : Icon
        {
            public Close()
                : base("Close",
                        IconVariant.Regular,
                        IconSize.Size10,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 32 32\"><path fill=\"#444791\" d=\"M16 2C8.2 2 2 8.2 2 16s6.2 14 14 14s14-6.2 14-14S23.8 2 16 2m0 26C9.4 28 4 22.6 4 16S9.4 4 16 4s12 5.4 12 12s-5.4 12-12 12\"/><path fill=\"#444791\" d=\"M21.4 23L16 17.6L10.6 23L9 21.4l5.4-5.4L9 10.6L10.6 9l5.4 5.4L21.4 9l1.6 1.6l-5.4 5.4l5.4 5.4z\"/></svg>"
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
        public class Projects1 : Icon
        {
            public Projects1()
                : base("Projects1",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Projects2 : Icon
        {
            public Projects2()
                : base("Projects2",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 256 256\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M88 144v-16a8 8 0 0 1 16 0v16a8 8 0 0 1-16 0m40 8a8 8 0 0 0 8-8v-24a8 8 0 0 0-16 0v24a8 8 0 0 0 8 8m32 0a8 8 0 0 0 8-8v-32a8 8 0 0 0-16 0v32a8 8 0 0 0 8 8m56-72v96h8a8 8 0 0 1 0 16h-88v17.38a24 24 0 1 1-16 0V192H32a8 8 0 0 1 0-16h8V80a16 16 0 0 1-16-16V48a16 16 0 0 1 16-16h176a16 16 0 0 1 16 16v16a16 16 0 0 1-16 16m-80 152a8 8 0 1 0-8 8a8 8 0 0 0 8-8M40 64h176V48H40Zm160 16H56v96h144Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Stages : Icon
        {
            public Stages()
                : base("Stages",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Categories : Icon
        {
            public Categories()
                : base("Categories",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m6.76 6l.45.89L7.76 8H12v5H4V6zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8V6zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55M6.76 19l.45.89l.55 1.11H12v5H4v-7zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8v-7zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SubCategories : Icon
        {
            public SubCategories()
                : base("SubCategories",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M20 26h6v2h-6zm0-8h8v2h-8zm0-8h10v2H20zm-5-6h2v24h-2zm-4.414-.041L7 7.249L3.412 3.958L2 5.373L7 10l5-4.627z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Issues : Icon
        {
            public Issues()
                : base("Issues",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 1024 1024\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M464 688a48 48 0 1 0 96 0a48 48 0 1 0-96 0m72-112c4.4 0 8-3.6 8-8V296c0-4.4-3.6-8-8-8h-48c-4.4 0-8 3.6-8 8v272c0 4.4 3.6 8 8 8zm400-188h-59.3c-2.6 0-5 1.2-6.5 3.3L763.7 538.1l-49.9-68.8a7.92 7.92 0 0 0-6.5-3.3H648c-6.5 0-10.3 7.4-6.5 12.7l109.2 150.7a16.1 16.1 0 0 0 26 0l165.8-228.7c3.8-5.3 0-12.7-6.5-12.7m-44 306h-64.2c-5.5 0-10.6 2.9-13.6 7.5a352.2 352.2 0 0 1-49.8 62.2A355.9 355.9 0 0 1 651.1 840a355 355 0 0 1-138.7 27.9c-48.1 0-94.8-9.4-138.7-27.9a355.9 355.9 0 0 1-113.3-76.3A353.1 353.1 0 0 1 184 650.5c-18.6-43.8-28-90.5-28-138.5s9.4-94.7 28-138.5c17.9-42.4 43.6-80.5 76.4-113.2s70.9-58.4 113.3-76.3a355 355 0 0 1 138.7-27.9c48.1 0 94.8 9.4 138.7 27.9c42.4 17.9 80.5 43.6 113.3 76.3c19 19 35.6 39.8 49.8 62.2c2.9 4.7 8.1 7.5 13.6 7.5H892c6 0 9.8-6.3 7.2-11.6C828.8 178.5 684.7 82 517.7 80C278.9 77.2 80.5 272.5 80 511.2C79.5 750.1 273.3 944 512.4 944c169.2 0 315.6-97 386.7-238.4A8 8 0 0 0 892 694\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers1 : Icon
        {
            public Offers1()
                : base("Offers1",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M21 13c.6 0 1.1.2 1.4.6c.4.4.6.9.6 1.4l-8 3l-7-2V7h1.9l7.3 2.7c.5.2.8.6.8 1.1c0 .3-.1.6-.3.8s-.5.4-.9.4H14l-1.7-.7l-.3.9l2 .8zM2 7h4v11H2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers2 : Icon
        {
            public Offers2()
                : base("Offers2",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"10\" height=\"10\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m20.749 12l1.104-1.908a1 1 0 0 0-.365-1.366l-1.91-1.104v-2.2a1 1 0 0 0-1-1h-2.199l-1.103-1.909a1.008 1.008 0 0 0-.607-.466a.993.993 0 0 0-.759.1L12 3.251l-1.91-1.105a1 1 0 0 0-1.366.366L7.62 4.422H5.421a1 1 0 0 0-1 1v2.199l-1.91 1.104a.998.998 0 0 0-.365 1.367L3.25 12l-1.104 1.908a1.004 1.004 0 0 0 .364 1.367l1.91 1.104v2.199a1 1 0 0 0 1 1h2.2l1.104 1.91a1.01 1.01 0 0 0 .866.5c.174 0 .347-.046.501-.135l1.908-1.104l1.91 1.104a1.001 1.001 0 0 0 1.366-.365l1.103-1.91h2.199a1 1 0 0 0 1-1v-2.199l1.91-1.104a1 1 0 0 0 .365-1.367zM9.499 6.99a1.5 1.5 0 1 1-.001 3.001a1.5 1.5 0 0 1 .001-3.001m.3 9.6l-1.6-1.199l6-8l1.6 1.199zm4.7.4a1.5 1.5 0 1 1 .001-3.001a1.5 1.5 0 0 1-.001 3.001\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Types : Icon
        {
            public Types()
                : base("Types",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M22 17a5 5 0 1 1-10.001-.001A5 5 0 0 1 22 17M6.5 6.5h3.8L7 1L1 11h5.5zm9.5 4.085V8H8v8h2.585A6.505 6.505 0 0 1 16 10.585\" />\r\n</svg>"
                      )
            {
            }
        }
        public class States : Icon
        {
            public States()
                : base("States",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices1 : Icon
        {
            public Invoices1()
                : base("Invoices1",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M4.4 10.2c-.6.1-1.4-.3-1.7-.4l-.5.9s.9.4 1.7.5v.8h1v-.9c.9-.3 1.4-1.1 1.5-1.8c0-.8-.6-1.4-1.9-1.9c-.4-.2-1.1-.5-1.1-.9c0-.5.4-.8 1-.8c.7 0 1.4.3 1.4.3l.4-.9s-.5-.2-1.2-.4V4H4v.7c-.9.2-1.5.8-1.6 1.7c0 1.2 1.3 1.7 1.8 1.9c.6.2 1.3.6 1.3.9c0 .4-.4.9-1.1 1\" />\r\n\t<path fill=\"#444791\" d=\"M0 2v12h16V2zm15 11H1V3h14z\" />\r\n\t<path fill=\"#444791\" d=\"M8 5h6v1H8zm0 2h6v1H8zm0 2h3v1H8z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices2 : Icon
        {
            public Invoices2()
                : base("Invoices2",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M6 3v26h16v-2H8V5h10v6h6v2h2V9.6l-.3-.3l-6-6l-.3-.3zm14 3.4L22.6 9H20zM10 13v2h12v-2zm17 2v2c-1.7.3-3 1.7-3 3.5c0 2 1.5 3.5 3.5 3.5h1c.8 0 1.5.7 1.5 1.5s-.7 1.5-1.5 1.5H25v2h2v2h2v-2c1.7-.3 3-1.7 3-3.5c0-2-1.5-3.5-3.5-3.5h-1c-.8 0-1.5-.7-1.5-1.5s.7-1.5 1.5-1.5H31v-2h-2v-2zm-17 3v2h7v-2zm9 0v2h3v-2zm-9 4v2h7v-2zm9 0v2h3v-2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments1 : Icon
        {
            public Payments1()
                : base("Payments1",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m17.5 16.82l2.44 1.41l-.75 1.3L16 17.69V14h1.5zM24 17c0 3.87-3.13 7-7 7s-7-3.13-7-7c0-.34.03-.67.08-1H2V4h18v6.68c2.36 1.13 4 3.53 4 6.32m-13.32-3c.18-.36.37-.7.6-1.03c-.09.03-.18.03-.28.03c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3c0 .25-.04.5-.1.73c.94-.46 1.99-.73 3.1-.73c.34 0 .67.03 1 .08V8a2 2 0 0 1-2-2H6c0 1.11-.89 2-2 2v4a2 2 0 0 1 2 2zM22 17c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5s5-2.24 5-5\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments2 : Icon
        {
            public Payments2()
                : base("Payments2",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 10a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1zM1 5.5A2.5 2.5 0 0 1 3.5 3h9A2.5 2.5 0 0 1 15 5.5v5a2.5 2.5 0 0 1-2.5 2.5h-9A2.5 2.5 0 0 1 1 10.5zM14 6v-.5A1.5 1.5 0 0 0 12.5 4h-9A1.5 1.5 0 0 0 2 5.5V6zM2 7v3.5A1.5 1.5 0 0 0 3.5 12h9a1.5 1.5 0 0 0 1.5-1.5V7z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines1 : Icon
        {
            public Disciplines1()
                : base("Disciplines1",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\" d=\"M6 18h36v6a6 6 0 0 1-6 6H12a6 6 0 0 1-6-6zm34 24H8m5 0l3-12m19 12l-3-12m-2-12L27 4h-6l-3 14m18-7h4M8 11h4\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines2 : Icon
        {
            public Disciplines2()
                : base("Disciplines2",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<rect width=\"36\" height=\"20\" x=\"6\" y=\"6\" rx=\"2\" />\r\n\t\t<path stroke-linecap=\"round\" d=\"M14 13h8m-8 6h20M8 44l4.889-6h21.778L40 44M24 26v18\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables1 : Icon
        {
            public Deliverables1()
                : base("Deliverables1",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m23 1l-6 6l1.415 1.402L22 4.818V21H10V10H8v11c0 1.103.897 2 2 2h12c1.103 0 2-.897 2-2V4.815l3.586 3.587L29 7z\" />\r\n\t<path fill=\"#444791\" d=\"M18.5 19h-5c-.827 0-1.5-.673-1.5-1.5v-5c0-.827.673-1.5 1.5-1.5h5c.827 0 1.5.673 1.5 1.5v5c0 .827-.673 1.5-1.5 1.5M14 17h4v-4h-4zm2 14v-2c7.168 0 13-5.832 13-13c0-1.265-.181-2.514-.538-3.715l1.917-.57C30.79 13.1 31 14.542 31 16c0 8.271-6.729 15-15 15M1.621 20.285A15.011 15.011 0 0 1 1 16C1 7.729 7.729 1 16 1v2C8.832 3 3 8.832 3 16c0 1.265.181 2.515.538 3.715z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables2 : Icon
        {
            public Deliverables2()
                : base("Deliverables2",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<path d=\"m20 33l6 2s15-3 17-3s2 2 0 4s-9 8-15 8s-10-3-14-3H4\" />\r\n\t\t<path d=\"M4 29c2-2 6-5 10-5s13.5 4 15 6s-3 5-3 5M16 18v-8a2 2 0 0 1 2-2h24a2 2 0 0 1 2 2v16\" />\r\n\t\t<path d=\"M25 8h10v9H25z\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks1 : Icon
        {
            public SupportiveWorks1()
                : base("SupportiveWorks1",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-width=\"2\" d=\"M19 7s-5 7-12.5 7c-2 0-5.5 1-5.5 5v4h11v-4c0-2.5 3-1 7-8l-1.5-1.5M3 5V2h20v14h-3M11 1h4v2h-4zM6.5 14a3.5 3.5 0 1 0 0-7a3.5 3.5 0 0 0 0 7Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks2 : Icon
        {
            public SupportiveWorks2()
                : base("SupportiveWorks2",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M16 32C7.125 32 0 24.776 0 16C0 7.125 7.125 0 16 0s16 7.125 16 16c0 8.776-7.125 16-16 16m0-29.312c-7.328 0-13.318 5.984-13.318 13.313S8.672 29.319 16 29.319c7.328 0 13.318-5.99 13.318-13.318S23.328 2.688 16 2.688m7.849 14.859H12.286a.927.927 0 0 1-.932-.917v-1.349c0-.521.411-.932.932-.932h11.661c.516 0 .927.417.927.932v1.339c-.099.516-.516.927-1.026.927zm-2.995-5.162H9.187a.925.925 0 0 1-.932-.917v-1.349c0-.417.417-.828.932-.828h11.661c.417 0 .828.417.828.828v1.339c0 .516-.411.927-.823.927zm-11.666 7.23h11.667c.516 0 .927.411.927.927v1.339a.928.928 0 0 1-.922.932H9.188c-.516-.104-.927-.516-.927-1.031v-1.344c-.005-.411.411-.823.927-.823\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Documents : Icon
        {
            public Documents()
                : base("Documents",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M40.358 12.581L26.363 6.04a5.74 5.74 0 0 0-4.857-.001l-13.863 6.47a2.295 2.295 0 0 0-.001 4.159l13.995 6.541a5.74 5.74 0 0 0 4.857.002l13.863-6.471a2.295 2.295 0 0 0 .001-4.159\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m13.227 19.278l-5.584 2.606a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.002l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M13.227 28.654L7.643 31.26a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.001l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Download : Icon
        {
            public Download()
                : base("Download",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m12 16l-5-5l1.4-1.45l2.6 2.6V4h2v8.15l2.6-2.6L17 11zm-6 4q-.825 0-1.412-.587T4 18v-3h2v3h12v-3h2v3q0 .825-.587 1.413T18 20z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Contract : Icon
        {
            public Contract()
                : base("Contract",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 36 36\"><path fill=\"#444791\" d=\"M8 8.2h16v1.6H8zm0 8h8.086v1.6H8zm15.378-4H8v1.6h13.779zM12.794 29.072a2.47 2.47 0 0 0 2.194.824h7.804a.7.7 0 0 0 0-1.4h-7.804c-.911-.016-.749-.807-.621-1.052a3.962 3.962 0 0 0 .387-.915a1.183 1.183 0 0 0-.616-1.322a1.899 1.899 0 0 0-2.24.517c-.344.355-.822.898-1.28 1.426c.283-1.109.65-2.532 1.01-3.92a1.315 1.315 0 0 0-.755-1.626a1.425 1.425 0 0 0-1.775.793c-.432.831-3.852 6.562-3.886 6.62a.7.7 0 1 0 1.202.718c.128-.215 2.858-4.788 3.719-6.315c-.648 2.5-1.362 5.282-1.404 5.532a.869.869 0 0 0 .407.969a.92.92 0 0 0 1.106-.224c.126-.114.362-.385.957-1.076a62.093 62.093 0 0 1 1.703-1.921c.218-.23.35-.128.222.098a2.291 2.291 0 0 0-.33 2.274\"/><path fill=\"#444791\" d=\"M28 21.695V32H4V4h24v4.993l1.33-1.33a4.304 4.304 0 0 1 .67-.54V3a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v30a1 1 0 0 0 1 1h26a1 1 0 0 0 1-1V21.427a2.91 2.91 0 0 1-2 .268\"/><path fill=\"#444791\" d=\"m34.128 11.861l-.523-.523a1.898 1.898 0 0 0-.11-2.423a1.956 1.956 0 0 0-2.75.162L18.22 21.6l-.837 3.142a.234.234 0 0 0 .296.294l3.131-.847l11.692-11.692l.494.495a.371.371 0 0 1 0 .525l-4.917 4.917a.8.8 0 0 0 1.132 1.131l4.917-4.917a1.972 1.972 0 0 0 0-2.788\"/></svg>"
                      )
            {
            }
        }
        public class Result : Icon
        {
            public Result()
                : base("Result",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 2048 2048\"><path fill=\"#444791\" d=\"M1664 1792v-128H0v128zm384-1408V256h-128v128zm0 1024v-128h-128v128zm-384 0v-128H0v128zm0-1152H0v128h1664zm0 512V640H0v128z\"/></svg>"
                      )
            {
            }
        }
        public class Save : Icon
        {
            public Save()
                : base("Save",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 24 24\"><path fill=\"#444791\" d=\"M2 2h14.414L22 7.586V22H2zm2 2v16h2v-6h12v6h2V8.414L15.586 4H13v4H6V4zm4 0v2h3V4zm8 16v-4H8v4z\"/></svg>"
                      )
            {
            }
        }
        public class Expenses : Icon
        {
            public Expenses()
                : base("Expenses",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 48 48\"><g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m16.517 14.344l7.705-4.8l10.274 8.688v12.566l-5.967 4.836V23.817zm9.541-5.086L31.9 5.646l10.46 7.293l-6.433 4.926m.277 10.748l6.296-5.14m-6.296 2.479l6.296-5.14m-6.296 2.48l6.296-5.14m-6.296 2.48l6.296-5.14\"/><path d=\"m35.314 14.172l2.723-2.077l-1.865-1.247l-1.498 1.131M5.5 31.954l13.543 10.4l7.423-5.91\"/><path d=\"m5.5 29.285l13.543 10.4l7.423-5.91\"/><path d=\"m5.604 26.616l13.543 10.401l7.423-5.91\"/><path d=\"m5.59 23.948l13.542 10.4l7.423-5.91m-6.32-4.688c-.226 1.027-1.694 1.554-3.278 1.175h0c-1.584-.378-2.685-1.517-2.459-2.545c.226-1.027 1.694-1.553 3.278-1.175s2.685 1.518 2.459 2.545\"/><path d=\"m15.051 15.826l-9.295 5.595l13.331 10.117l7.64-6.015\"/></g></svg>"
                      )
            {
            }
        }
        public class Close : Icon
        {
            public Close()
                : base("Close",
                        IconVariant.Regular,
                        IconSize.Size12,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"12\" height=\"12\" viewBox=\"0 0 32 32\"><path fill=\"#444791\" d=\"M16 2C8.2 2 2 8.2 2 16s6.2 14 14 14s14-6.2 14-14S23.8 2 16 2m0 26C9.4 28 4 22.6 4 16S9.4 4 16 4s12 5.4 12 12s-5.4 12-12 12\"/><path fill=\"#444791\" d=\"M21.4 23L16 17.6L10.6 23L9 21.4l5.4-5.4L9 10.6L10.6 9l5.4 5.4L21.4 9l1.6 1.6l-5.4 5.4l5.4 5.4z\"/></svg>"
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
        public class Projects1 : Icon
        {
            public Projects1()
                : base("Projects1",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Projects2 : Icon
        {
            public Projects2()
                : base("Projects2",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 256 256\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M88 144v-16a8 8 0 0 1 16 0v16a8 8 0 0 1-16 0m40 8a8 8 0 0 0 8-8v-24a8 8 0 0 0-16 0v24a8 8 0 0 0 8 8m32 0a8 8 0 0 0 8-8v-32a8 8 0 0 0-16 0v32a8 8 0 0 0 8 8m56-72v96h8a8 8 0 0 1 0 16h-88v17.38a24 24 0 1 1-16 0V192H32a8 8 0 0 1 0-16h8V80a16 16 0 0 1-16-16V48a16 16 0 0 1 16-16h176a16 16 0 0 1 16 16v16a16 16 0 0 1-16 16m-80 152a8 8 0 1 0-8 8a8 8 0 0 0 8-8M40 64h176V48H40Zm160 16H56v96h144Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Stages : Icon
        {
            public Stages()
                : base("Stages",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Categories : Icon
        {
            public Categories()
                : base("Categories",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m6.76 6l.45.89L7.76 8H12v5H4V6zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8V6zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55M6.76 19l.45.89l.55 1.11H12v5H4v-7zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8v-7zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SubCategories : Icon
        {
            public SubCategories()
                : base("SubCategories",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M20 26h6v2h-6zm0-8h8v2h-8zm0-8h10v2H20zm-5-6h2v24h-2zm-4.414-.041L7 7.249L3.412 3.958L2 5.373L7 10l5-4.627z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Issues : Icon
        {
            public Issues()
                : base("Issues",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 1024 1024\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M464 688a48 48 0 1 0 96 0a48 48 0 1 0-96 0m72-112c4.4 0 8-3.6 8-8V296c0-4.4-3.6-8-8-8h-48c-4.4 0-8 3.6-8 8v272c0 4.4 3.6 8 8 8zm400-188h-59.3c-2.6 0-5 1.2-6.5 3.3L763.7 538.1l-49.9-68.8a7.92 7.92 0 0 0-6.5-3.3H648c-6.5 0-10.3 7.4-6.5 12.7l109.2 150.7a16.1 16.1 0 0 0 26 0l165.8-228.7c3.8-5.3 0-12.7-6.5-12.7m-44 306h-64.2c-5.5 0-10.6 2.9-13.6 7.5a352.2 352.2 0 0 1-49.8 62.2A355.9 355.9 0 0 1 651.1 840a355 355 0 0 1-138.7 27.9c-48.1 0-94.8-9.4-138.7-27.9a355.9 355.9 0 0 1-113.3-76.3A353.1 353.1 0 0 1 184 650.5c-18.6-43.8-28-90.5-28-138.5s9.4-94.7 28-138.5c17.9-42.4 43.6-80.5 76.4-113.2s70.9-58.4 113.3-76.3a355 355 0 0 1 138.7-27.9c48.1 0 94.8 9.4 138.7 27.9c42.4 17.9 80.5 43.6 113.3 76.3c19 19 35.6 39.8 49.8 62.2c2.9 4.7 8.1 7.5 13.6 7.5H892c6 0 9.8-6.3 7.2-11.6C828.8 178.5 684.7 82 517.7 80C278.9 77.2 80.5 272.5 80 511.2C79.5 750.1 273.3 944 512.4 944c169.2 0 315.6-97 386.7-238.4A8 8 0 0 0 892 694\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers1 : Icon
        {
            public Offers1()
                : base("Offers1",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M21 13c.6 0 1.1.2 1.4.6c.4.4.6.9.6 1.4l-8 3l-7-2V7h1.9l7.3 2.7c.5.2.8.6.8 1.1c0 .3-.1.6-.3.8s-.5.4-.9.4H14l-1.7-.7l-.3.9l2 .8zM2 7h4v11H2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers2 : Icon
        {
            public Offers2()
                : base("Offers2",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m20.749 12l1.104-1.908a1 1 0 0 0-.365-1.366l-1.91-1.104v-2.2a1 1 0 0 0-1-1h-2.199l-1.103-1.909a1.008 1.008 0 0 0-.607-.466a.993.993 0 0 0-.759.1L12 3.251l-1.91-1.105a1 1 0 0 0-1.366.366L7.62 4.422H5.421a1 1 0 0 0-1 1v2.199l-1.91 1.104a.998.998 0 0 0-.365 1.367L3.25 12l-1.104 1.908a1.004 1.004 0 0 0 .364 1.367l1.91 1.104v2.199a1 1 0 0 0 1 1h2.2l1.104 1.91a1.01 1.01 0 0 0 .866.5c.174 0 .347-.046.501-.135l1.908-1.104l1.91 1.104a1.001 1.001 0 0 0 1.366-.365l1.103-1.91h2.199a1 1 0 0 0 1-1v-2.199l1.91-1.104a1 1 0 0 0 .365-1.367zM9.499 6.99a1.5 1.5 0 1 1-.001 3.001a1.5 1.5 0 0 1 .001-3.001m.3 9.6l-1.6-1.199l6-8l1.6 1.199zm4.7.4a1.5 1.5 0 1 1 .001-3.001a1.5 1.5 0 0 1-.001 3.001\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Types : Icon
        {
            public Types()
                : base("Types",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M22 17a5 5 0 1 1-10.001-.001A5 5 0 0 1 22 17M6.5 6.5h3.8L7 1L1 11h5.5zm9.5 4.085V8H8v8h2.585A6.505 6.505 0 0 1 16 10.585\" />\r\n</svg>"
                      )
            {
            }
        }
        public class States : Icon
        {
            public States()
                : base("States",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices1 : Icon
        {
            public Invoices1()
                : base("Invoices1",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M4.4 10.2c-.6.1-1.4-.3-1.7-.4l-.5.9s.9.4 1.7.5v.8h1v-.9c.9-.3 1.4-1.1 1.5-1.8c0-.8-.6-1.4-1.9-1.9c-.4-.2-1.1-.5-1.1-.9c0-.5.4-.8 1-.8c.7 0 1.4.3 1.4.3l.4-.9s-.5-.2-1.2-.4V4H4v.7c-.9.2-1.5.8-1.6 1.7c0 1.2 1.3 1.7 1.8 1.9c.6.2 1.3.6 1.3.9c0 .4-.4.9-1.1 1\" />\r\n\t<path fill=\"#444791\" d=\"M0 2v12h16V2zm15 11H1V3h14z\" />\r\n\t<path fill=\"#444791\" d=\"M8 5h6v1H8zm0 2h6v1H8zm0 2h3v1H8z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices2 : Icon
        {
            public Invoices2()
                : base("Invoices2",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M6 3v26h16v-2H8V5h10v6h6v2h2V9.6l-.3-.3l-6-6l-.3-.3zm14 3.4L22.6 9H20zM10 13v2h12v-2zm17 2v2c-1.7.3-3 1.7-3 3.5c0 2 1.5 3.5 3.5 3.5h1c.8 0 1.5.7 1.5 1.5s-.7 1.5-1.5 1.5H25v2h2v2h2v-2c1.7-.3 3-1.7 3-3.5c0-2-1.5-3.5-3.5-3.5h-1c-.8 0-1.5-.7-1.5-1.5s.7-1.5 1.5-1.5H31v-2h-2v-2zm-17 3v2h7v-2zm9 0v2h3v-2zm-9 4v2h7v-2zm9 0v2h3v-2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments1 : Icon
        {
            public Payments1()
                : base("Payments1",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m17.5 16.82l2.44 1.41l-.75 1.3L16 17.69V14h1.5zM24 17c0 3.87-3.13 7-7 7s-7-3.13-7-7c0-.34.03-.67.08-1H2V4h18v6.68c2.36 1.13 4 3.53 4 6.32m-13.32-3c.18-.36.37-.7.6-1.03c-.09.03-.18.03-.28.03c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3c0 .25-.04.5-.1.73c.94-.46 1.99-.73 3.1-.73c.34 0 .67.03 1 .08V8a2 2 0 0 1-2-2H6c0 1.11-.89 2-2 2v4a2 2 0 0 1 2 2zM22 17c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5s5-2.24 5-5\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments2 : Icon
        {
            public Payments2()
                : base("Payments2",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 10a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1zM1 5.5A2.5 2.5 0 0 1 3.5 3h9A2.5 2.5 0 0 1 15 5.5v5a2.5 2.5 0 0 1-2.5 2.5h-9A2.5 2.5 0 0 1 1 10.5zM14 6v-.5A1.5 1.5 0 0 0 12.5 4h-9A1.5 1.5 0 0 0 2 5.5V6zM2 7v3.5A1.5 1.5 0 0 0 3.5 12h9a1.5 1.5 0 0 0 1.5-1.5V7z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines1 : Icon
        {
            public Disciplines1()
                : base("Disciplines1",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\" d=\"M6 18h36v6a6 6 0 0 1-6 6H12a6 6 0 0 1-6-6zm34 24H8m5 0l3-12m19 12l-3-12m-2-12L27 4h-6l-3 14m18-7h4M8 11h4\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines2 : Icon
        {
            public Disciplines2()
                : base("Disciplines2",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<rect width=\"36\" height=\"20\" x=\"6\" y=\"6\" rx=\"2\" />\r\n\t\t<path stroke-linecap=\"round\" d=\"M14 13h8m-8 6h20M8 44l4.889-6h21.778L40 44M24 26v18\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables1 : Icon
        {
            public Deliverables1()
                : base("Deliverables1",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m23 1l-6 6l1.415 1.402L22 4.818V21H10V10H8v11c0 1.103.897 2 2 2h12c1.103 0 2-.897 2-2V4.815l3.586 3.587L29 7z\" />\r\n\t<path fill=\"#444791\" d=\"M18.5 19h-5c-.827 0-1.5-.673-1.5-1.5v-5c0-.827.673-1.5 1.5-1.5h5c.827 0 1.5.673 1.5 1.5v5c0 .827-.673 1.5-1.5 1.5M14 17h4v-4h-4zm2 14v-2c7.168 0 13-5.832 13-13c0-1.265-.181-2.514-.538-3.715l1.917-.57C30.79 13.1 31 14.542 31 16c0 8.271-6.729 15-15 15M1.621 20.285A15.011 15.011 0 0 1 1 16C1 7.729 7.729 1 16 1v2C8.832 3 3 8.832 3 16c0 1.265.181 2.515.538 3.715z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables2 : Icon
        {
            public Deliverables2()
                : base("Deliverables2",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<path d=\"m20 33l6 2s15-3 17-3s2 2 0 4s-9 8-15 8s-10-3-14-3H4\" />\r\n\t\t<path d=\"M4 29c2-2 6-5 10-5s13.5 4 15 6s-3 5-3 5M16 18v-8a2 2 0 0 1 2-2h24a2 2 0 0 1 2 2v16\" />\r\n\t\t<path d=\"M25 8h10v9H25z\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks1 : Icon
        {
            public SupportiveWorks1()
                : base("SupportiveWorks1",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-width=\"2\" d=\"M19 7s-5 7-12.5 7c-2 0-5.5 1-5.5 5v4h11v-4c0-2.5 3-1 7-8l-1.5-1.5M3 5V2h20v14h-3M11 1h4v2h-4zM6.5 14a3.5 3.5 0 1 0 0-7a3.5 3.5 0 0 0 0 7Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks2 : Icon
        {
            public SupportiveWorks2()
                : base("SupportiveWorks2",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M16 32C7.125 32 0 24.776 0 16C0 7.125 7.125 0 16 0s16 7.125 16 16c0 8.776-7.125 16-16 16m0-29.312c-7.328 0-13.318 5.984-13.318 13.313S8.672 29.319 16 29.319c7.328 0 13.318-5.99 13.318-13.318S23.328 2.688 16 2.688m7.849 14.859H12.286a.927.927 0 0 1-.932-.917v-1.349c0-.521.411-.932.932-.932h11.661c.516 0 .927.417.927.932v1.339c-.099.516-.516.927-1.026.927zm-2.995-5.162H9.187a.925.925 0 0 1-.932-.917v-1.349c0-.417.417-.828.932-.828h11.661c.417 0 .828.417.828.828v1.339c0 .516-.411.927-.823.927zm-11.666 7.23h11.667c.516 0 .927.411.927.927v1.339a.928.928 0 0 1-.922.932H9.188c-.516-.104-.927-.516-.927-1.031v-1.344c-.005-.411.411-.823.927-.823\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Documents : Icon
        {
            public Documents()
                : base("Documents",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M40.358 12.581L26.363 6.04a5.74 5.74 0 0 0-4.857-.001l-13.863 6.47a2.295 2.295 0 0 0-.001 4.159l13.995 6.541a5.74 5.74 0 0 0 4.857.002l13.863-6.471a2.295 2.295 0 0 0 .001-4.159\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m13.227 19.278l-5.584 2.606a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.002l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M13.227 28.654L7.643 31.26a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.001l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Download : Icon
        {
            public Download()
                : base("Download",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m12 16l-5-5l1.4-1.45l2.6 2.6V4h2v8.15l2.6-2.6L17 11zm-6 4q-.825 0-1.412-.587T4 18v-3h2v3h12v-3h2v3q0 .825-.587 1.413T18 20z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Contract : Icon
        {
            public Contract()
                : base("Contract",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 36 36\"><path fill=\"#444791\" d=\"M8 8.2h16v1.6H8zm0 8h8.086v1.6H8zm15.378-4H8v1.6h13.779zM12.794 29.072a2.47 2.47 0 0 0 2.194.824h7.804a.7.7 0 0 0 0-1.4h-7.804c-.911-.016-.749-.807-.621-1.052a3.962 3.962 0 0 0 .387-.915a1.183 1.183 0 0 0-.616-1.322a1.899 1.899 0 0 0-2.24.517c-.344.355-.822.898-1.28 1.426c.283-1.109.65-2.532 1.01-3.92a1.315 1.315 0 0 0-.755-1.626a1.425 1.425 0 0 0-1.775.793c-.432.831-3.852 6.562-3.886 6.62a.7.7 0 1 0 1.202.718c.128-.215 2.858-4.788 3.719-6.315c-.648 2.5-1.362 5.282-1.404 5.532a.869.869 0 0 0 .407.969a.92.92 0 0 0 1.106-.224c.126-.114.362-.385.957-1.076a62.093 62.093 0 0 1 1.703-1.921c.218-.23.35-.128.222.098a2.291 2.291 0 0 0-.33 2.274\"/><path fill=\"#444791\" d=\"M28 21.695V32H4V4h24v4.993l1.33-1.33a4.304 4.304 0 0 1 .67-.54V3a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v30a1 1 0 0 0 1 1h26a1 1 0 0 0 1-1V21.427a2.91 2.91 0 0 1-2 .268\"/><path fill=\"#444791\" d=\"m34.128 11.861l-.523-.523a1.898 1.898 0 0 0-.11-2.423a1.956 1.956 0 0 0-2.75.162L18.22 21.6l-.837 3.142a.234.234 0 0 0 .296.294l3.131-.847l11.692-11.692l.494.495a.371.371 0 0 1 0 .525l-4.917 4.917a.8.8 0 0 0 1.132 1.131l4.917-4.917a1.972 1.972 0 0 0 0-2.788\"/></svg>"
                      )
            {
            }
        }
        public class Result : Icon
        {
            public Result()
                : base("Result",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 2048 2048\"><path fill=\"#444791\" d=\"M1664 1792v-128H0v128zm384-1408V256h-128v128zm0 1024v-128h-128v128zm-384 0v-128H0v128zm0-1152H0v128h1664zm0 512V640H0v128z\"/></svg>"
                      )
            {
            }
        }
        public class Save : Icon
        {
            public Save()
                : base("Save",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 24 24\"><path fill=\"#444791\" d=\"M2 2h14.414L22 7.586V22H2zm2 2v16h2v-6h12v6h2V8.414L15.586 4H13v4H6V4zm4 0v2h3V4zm8 16v-4H8v4z\"/></svg>"
                      )
            {
            }
        }
        public class Expenses : Icon
        {
            public Expenses()
                : base("Expenses",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 48 48\"><g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m16.517 14.344l7.705-4.8l10.274 8.688v12.566l-5.967 4.836V23.817zm9.541-5.086L31.9 5.646l10.46 7.293l-6.433 4.926m.277 10.748l6.296-5.14m-6.296 2.479l6.296-5.14m-6.296 2.48l6.296-5.14m-6.296 2.48l6.296-5.14\"/><path d=\"m35.314 14.172l2.723-2.077l-1.865-1.247l-1.498 1.131M5.5 31.954l13.543 10.4l7.423-5.91\"/><path d=\"m5.5 29.285l13.543 10.4l7.423-5.91\"/><path d=\"m5.604 26.616l13.543 10.401l7.423-5.91\"/><path d=\"m5.59 23.948l13.542 10.4l7.423-5.91m-6.32-4.688c-.226 1.027-1.694 1.554-3.278 1.175h0c-1.584-.378-2.685-1.517-2.459-2.545c.226-1.027 1.694-1.553 3.278-1.175s2.685 1.518 2.459 2.545\"/><path d=\"m15.051 15.826l-9.295 5.595l13.331 10.117l7.64-6.015\"/></g></svg>"
                      )
            {
            }
        }
        public class Close : Icon
        {
            public Close()
                : base("Close",
                        IconVariant.Regular,
                        IconSize.Size16,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"16\" height=\"16\" viewBox=\"0 0 32 32\"><path fill=\"#444791\" d=\"M16 2C8.2 2 2 8.2 2 16s6.2 14 14 14s14-6.2 14-14S23.8 2 16 2m0 26C9.4 28 4 22.6 4 16S9.4 4 16 4s12 5.4 12 12s-5.4 12-12 12\"/><path fill=\"#444791\" d=\"M21.4 23L16 17.6L10.6 23L9 21.4l5.4-5.4L9 10.6L10.6 9l5.4 5.4L21.4 9l1.6 1.6l-5.4 5.4l5.4 5.4z\"/></svg>"
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
        public class Projects1 : Icon
        {
            public Projects1()
                : base("Projects1",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Projects2 : Icon
        {
            public Projects2()
                : base("Projects2",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 256 256\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M88 144v-16a8 8 0 0 1 16 0v16a8 8 0 0 1-16 0m40 8a8 8 0 0 0 8-8v-24a8 8 0 0 0-16 0v24a8 8 0 0 0 8 8m32 0a8 8 0 0 0 8-8v-32a8 8 0 0 0-16 0v32a8 8 0 0 0 8 8m56-72v96h8a8 8 0 0 1 0 16h-88v17.38a24 24 0 1 1-16 0V192H32a8 8 0 0 1 0-16h8V80a16 16 0 0 1-16-16V48a16 16 0 0 1 16-16h176a16 16 0 0 1 16 16v16a16 16 0 0 1-16 16m-80 152a8 8 0 1 0-8 8a8 8 0 0 0 8-8M40 64h176V48H40Zm160 16H56v96h144Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Stages : Icon
        {
            public Stages()
                : base("Stages",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Categories : Icon
        {
            public Categories()
                : base("Categories",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m6.76 6l.45.89L7.76 8H12v5H4V6zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8V6zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55M6.76 19l.45.89l.55 1.11H12v5H4v-7zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8v-7zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SubCategories : Icon
        {
            public SubCategories()
                : base("SubCategories",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M20 26h6v2h-6zm0-8h8v2h-8zm0-8h10v2H20zm-5-6h2v24h-2zm-4.414-.041L7 7.249L3.412 3.958L2 5.373L7 10l5-4.627z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Issues : Icon
        {
            public Issues()
                : base("Issues",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 1024 1024\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M464 688a48 48 0 1 0 96 0a48 48 0 1 0-96 0m72-112c4.4 0 8-3.6 8-8V296c0-4.4-3.6-8-8-8h-48c-4.4 0-8 3.6-8 8v272c0 4.4 3.6 8 8 8zm400-188h-59.3c-2.6 0-5 1.2-6.5 3.3L763.7 538.1l-49.9-68.8a7.92 7.92 0 0 0-6.5-3.3H648c-6.5 0-10.3 7.4-6.5 12.7l109.2 150.7a16.1 16.1 0 0 0 26 0l165.8-228.7c3.8-5.3 0-12.7-6.5-12.7m-44 306h-64.2c-5.5 0-10.6 2.9-13.6 7.5a352.2 352.2 0 0 1-49.8 62.2A355.9 355.9 0 0 1 651.1 840a355 355 0 0 1-138.7 27.9c-48.1 0-94.8-9.4-138.7-27.9a355.9 355.9 0 0 1-113.3-76.3A353.1 353.1 0 0 1 184 650.5c-18.6-43.8-28-90.5-28-138.5s9.4-94.7 28-138.5c17.9-42.4 43.6-80.5 76.4-113.2s70.9-58.4 113.3-76.3a355 355 0 0 1 138.7-27.9c48.1 0 94.8 9.4 138.7 27.9c42.4 17.9 80.5 43.6 113.3 76.3c19 19 35.6 39.8 49.8 62.2c2.9 4.7 8.1 7.5 13.6 7.5H892c6 0 9.8-6.3 7.2-11.6C828.8 178.5 684.7 82 517.7 80C278.9 77.2 80.5 272.5 80 511.2C79.5 750.1 273.3 944 512.4 944c169.2 0 315.6-97 386.7-238.4A8 8 0 0 0 892 694\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers1 : Icon
        {
            public Offers1()
                : base("Offers1",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M21 13c.6 0 1.1.2 1.4.6c.4.4.6.9.6 1.4l-8 3l-7-2V7h1.9l7.3 2.7c.5.2.8.6.8 1.1c0 .3-.1.6-.3.8s-.5.4-.9.4H14l-1.7-.7l-.3.9l2 .8zM2 7h4v11H2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers2 : Icon
        {
            public Offers2()
                : base("Offers2",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m20.749 12l1.104-1.908a1 1 0 0 0-.365-1.366l-1.91-1.104v-2.2a1 1 0 0 0-1-1h-2.199l-1.103-1.909a1.008 1.008 0 0 0-.607-.466a.993.993 0 0 0-.759.1L12 3.251l-1.91-1.105a1 1 0 0 0-1.366.366L7.62 4.422H5.421a1 1 0 0 0-1 1v2.199l-1.91 1.104a.998.998 0 0 0-.365 1.367L3.25 12l-1.104 1.908a1.004 1.004 0 0 0 .364 1.367l1.91 1.104v2.199a1 1 0 0 0 1 1h2.2l1.104 1.91a1.01 1.01 0 0 0 .866.5c.174 0 .347-.046.501-.135l1.908-1.104l1.91 1.104a1.001 1.001 0 0 0 1.366-.365l1.103-1.91h2.199a1 1 0 0 0 1-1v-2.199l1.91-1.104a1 1 0 0 0 .365-1.367zM9.499 6.99a1.5 1.5 0 1 1-.001 3.001a1.5 1.5 0 0 1 .001-3.001m.3 9.6l-1.6-1.199l6-8l1.6 1.199zm4.7.4a1.5 1.5 0 1 1 .001-3.001a1.5 1.5 0 0 1-.001 3.001\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Types : Icon
        {
            public Types()
                : base("Types",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M22 17a5 5 0 1 1-10.001-.001A5 5 0 0 1 22 17M6.5 6.5h3.8L7 1L1 11h5.5zm9.5 4.085V8H8v8h2.585A6.505 6.505 0 0 1 16 10.585\" />\r\n</svg>"
                      )
            {
            }
        }
        public class States : Icon
        {
            public States()
                : base("States",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices1 : Icon
        {
            public Invoices1()
                : base("Invoices1",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M4.4 10.2c-.6.1-1.4-.3-1.7-.4l-.5.9s.9.4 1.7.5v.8h1v-.9c.9-.3 1.4-1.1 1.5-1.8c0-.8-.6-1.4-1.9-1.9c-.4-.2-1.1-.5-1.1-.9c0-.5.4-.8 1-.8c.7 0 1.4.3 1.4.3l.4-.9s-.5-.2-1.2-.4V4H4v.7c-.9.2-1.5.8-1.6 1.7c0 1.2 1.3 1.7 1.8 1.9c.6.2 1.3.6 1.3.9c0 .4-.4.9-1.1 1\" />\r\n\t<path fill=\"#444791\" d=\"M0 2v12h16V2zm15 11H1V3h14z\" />\r\n\t<path fill=\"#444791\" d=\"M8 5h6v1H8zm0 2h6v1H8zm0 2h3v1H8z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices2 : Icon
        {
            public Invoices2()
                : base("Invoices2",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M6 3v26h16v-2H8V5h10v6h6v2h2V9.6l-.3-.3l-6-6l-.3-.3zm14 3.4L22.6 9H20zM10 13v2h12v-2zm17 2v2c-1.7.3-3 1.7-3 3.5c0 2 1.5 3.5 3.5 3.5h1c.8 0 1.5.7 1.5 1.5s-.7 1.5-1.5 1.5H25v2h2v2h2v-2c1.7-.3 3-1.7 3-3.5c0-2-1.5-3.5-3.5-3.5h-1c-.8 0-1.5-.7-1.5-1.5s.7-1.5 1.5-1.5H31v-2h-2v-2zm-17 3v2h7v-2zm9 0v2h3v-2zm-9 4v2h7v-2zm9 0v2h3v-2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments1 : Icon
        {
            public Payments1()
                : base("Payments1",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m17.5 16.82l2.44 1.41l-.75 1.3L16 17.69V14h1.5zM24 17c0 3.87-3.13 7-7 7s-7-3.13-7-7c0-.34.03-.67.08-1H2V4h18v6.68c2.36 1.13 4 3.53 4 6.32m-13.32-3c.18-.36.37-.7.6-1.03c-.09.03-.18.03-.28.03c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3c0 .25-.04.5-.1.73c.94-.46 1.99-.73 3.1-.73c.34 0 .67.03 1 .08V8a2 2 0 0 1-2-2H6c0 1.11-.89 2-2 2v4a2 2 0 0 1 2 2zM22 17c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5s5-2.24 5-5\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments2 : Icon
        {
            public Payments2()
                : base("Payments2",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 10a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1zM1 5.5A2.5 2.5 0 0 1 3.5 3h9A2.5 2.5 0 0 1 15 5.5v5a2.5 2.5 0 0 1-2.5 2.5h-9A2.5 2.5 0 0 1 1 10.5zM14 6v-.5A1.5 1.5 0 0 0 12.5 4h-9A1.5 1.5 0 0 0 2 5.5V6zM2 7v3.5A1.5 1.5 0 0 0 3.5 12h9a1.5 1.5 0 0 0 1.5-1.5V7z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines1 : Icon
        {
            public Disciplines1()
                : base("Disciplines1",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\" d=\"M6 18h36v6a6 6 0 0 1-6 6H12a6 6 0 0 1-6-6zm34 24H8m5 0l3-12m19 12l-3-12m-2-12L27 4h-6l-3 14m18-7h4M8 11h4\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines2 : Icon
        {
            public Disciplines2()
                : base("Disciplines2",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<rect width=\"36\" height=\"20\" x=\"6\" y=\"6\" rx=\"2\" />\r\n\t\t<path stroke-linecap=\"round\" d=\"M14 13h8m-8 6h20M8 44l4.889-6h21.778L40 44M24 26v18\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables1 : Icon
        {
            public Deliverables1()
                : base("Deliverables1",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m23 1l-6 6l1.415 1.402L22 4.818V21H10V10H8v11c0 1.103.897 2 2 2h12c1.103 0 2-.897 2-2V4.815l3.586 3.587L29 7z\" />\r\n\t<path fill=\"#444791\" d=\"M18.5 19h-5c-.827 0-1.5-.673-1.5-1.5v-5c0-.827.673-1.5 1.5-1.5h5c.827 0 1.5.673 1.5 1.5v5c0 .827-.673 1.5-1.5 1.5M14 17h4v-4h-4zm2 14v-2c7.168 0 13-5.832 13-13c0-1.265-.181-2.514-.538-3.715l1.917-.57C30.79 13.1 31 14.542 31 16c0 8.271-6.729 15-15 15M1.621 20.285A15.011 15.011 0 0 1 1 16C1 7.729 7.729 1 16 1v2C8.832 3 3 8.832 3 16c0 1.265.181 2.515.538 3.715z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables2 : Icon
        {
            public Deliverables2()
                : base("Deliverables2",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<path d=\"m20 33l6 2s15-3 17-3s2 2 0 4s-9 8-15 8s-10-3-14-3H4\" />\r\n\t\t<path d=\"M4 29c2-2 6-5 10-5s13.5 4 15 6s-3 5-3 5M16 18v-8a2 2 0 0 1 2-2h24a2 2 0 0 1 2 2v16\" />\r\n\t\t<path d=\"M25 8h10v9H25z\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks1 : Icon
        {
            public SupportiveWorks1()
                : base("SupportiveWorks1",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-width=\"2\" d=\"M19 7s-5 7-12.5 7c-2 0-5.5 1-5.5 5v4h11v-4c0-2.5 3-1 7-8l-1.5-1.5M3 5V2h20v14h-3M11 1h4v2h-4zM6.5 14a3.5 3.5 0 1 0 0-7a3.5 3.5 0 0 0 0 7Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks2 : Icon
        {
            public SupportiveWorks2()
                : base("SupportiveWorks2",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M16 32C7.125 32 0 24.776 0 16C0 7.125 7.125 0 16 0s16 7.125 16 16c0 8.776-7.125 16-16 16m0-29.312c-7.328 0-13.318 5.984-13.318 13.313S8.672 29.319 16 29.319c7.328 0 13.318-5.99 13.318-13.318S23.328 2.688 16 2.688m7.849 14.859H12.286a.927.927 0 0 1-.932-.917v-1.349c0-.521.411-.932.932-.932h11.661c.516 0 .927.417.927.932v1.339c-.099.516-.516.927-1.026.927zm-2.995-5.162H9.187a.925.925 0 0 1-.932-.917v-1.349c0-.417.417-.828.932-.828h11.661c.417 0 .828.417.828.828v1.339c0 .516-.411.927-.823.927zm-11.666 7.23h11.667c.516 0 .927.411.927.927v1.339a.928.928 0 0 1-.922.932H9.188c-.516-.104-.927-.516-.927-1.031v-1.344c-.005-.411.411-.823.927-.823\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Documents : Icon
        {
            public Documents()
                : base("Documents",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M40.358 12.581L26.363 6.04a5.74 5.74 0 0 0-4.857-.001l-13.863 6.47a2.295 2.295 0 0 0-.001 4.159l13.995 6.541a5.74 5.74 0 0 0 4.857.002l13.863-6.471a2.295 2.295 0 0 0 .001-4.159\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m13.227 19.278l-5.584 2.606a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.002l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M13.227 28.654L7.643 31.26a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.001l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Download : Icon
        {
            public Download()
                : base("Download",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m12 16l-5-5l1.4-1.45l2.6 2.6V4h2v8.15l2.6-2.6L17 11zm-6 4q-.825 0-1.412-.587T4 18v-3h2v3h12v-3h2v3q0 .825-.587 1.413T18 20z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Contract : Icon
        {
            public Contract()
                : base("Contract",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 36 36\"><path fill=\"#444791\" d=\"M8 8.2h16v1.6H8zm0 8h8.086v1.6H8zm15.378-4H8v1.6h13.779zM12.794 29.072a2.47 2.47 0 0 0 2.194.824h7.804a.7.7 0 0 0 0-1.4h-7.804c-.911-.016-.749-.807-.621-1.052a3.962 3.962 0 0 0 .387-.915a1.183 1.183 0 0 0-.616-1.322a1.899 1.899 0 0 0-2.24.517c-.344.355-.822.898-1.28 1.426c.283-1.109.65-2.532 1.01-3.92a1.315 1.315 0 0 0-.755-1.626a1.425 1.425 0 0 0-1.775.793c-.432.831-3.852 6.562-3.886 6.62a.7.7 0 1 0 1.202.718c.128-.215 2.858-4.788 3.719-6.315c-.648 2.5-1.362 5.282-1.404 5.532a.869.869 0 0 0 .407.969a.92.92 0 0 0 1.106-.224c.126-.114.362-.385.957-1.076a62.093 62.093 0 0 1 1.703-1.921c.218-.23.35-.128.222.098a2.291 2.291 0 0 0-.33 2.274\"/><path fill=\"#444791\" d=\"M28 21.695V32H4V4h24v4.993l1.33-1.33a4.304 4.304 0 0 1 .67-.54V3a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v30a1 1 0 0 0 1 1h26a1 1 0 0 0 1-1V21.427a2.91 2.91 0 0 1-2 .268\"/><path fill=\"#444791\" d=\"m34.128 11.861l-.523-.523a1.898 1.898 0 0 0-.11-2.423a1.956 1.956 0 0 0-2.75.162L18.22 21.6l-.837 3.142a.234.234 0 0 0 .296.294l3.131-.847l11.692-11.692l.494.495a.371.371 0 0 1 0 .525l-4.917 4.917a.8.8 0 0 0 1.132 1.131l4.917-4.917a1.972 1.972 0 0 0 0-2.788\"/></svg>"
                      )
            {
            }
        }
        public class Result : Icon
        {
            public Result()
                : base("Result",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 2048 2048\"><path fill=\"#444791\" d=\"M1664 1792v-128H0v128zm384-1408V256h-128v128zm0 1024v-128h-128v128zm-384 0v-128H0v128zm0-1152H0v128h1664zm0 512V640H0v128z\"/></svg>"
                      )
            {
            }
        }
        public class Save : Icon
        {
            public Save()
                : base("Save",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 24 24\"><path fill=\"#444791\" d=\"M2 2h14.414L22 7.586V22H2zm2 2v16h2v-6h12v6h2V8.414L15.586 4H13v4H6V4zm4 0v2h3V4zm8 16v-4H8v4z\"/></svg>"
                      )
            {
            }
        }
        public class Expenses : Icon
        {
            public Expenses()
                : base("Expenses",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 48 48\"><g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m16.517 14.344l7.705-4.8l10.274 8.688v12.566l-5.967 4.836V23.817zm9.541-5.086L31.9 5.646l10.46 7.293l-6.433 4.926m.277 10.748l6.296-5.14m-6.296 2.479l6.296-5.14m-6.296 2.48l6.296-5.14m-6.296 2.48l6.296-5.14\"/><path d=\"m35.314 14.172l2.723-2.077l-1.865-1.247l-1.498 1.131M5.5 31.954l13.543 10.4l7.423-5.91\"/><path d=\"m5.5 29.285l13.543 10.4l7.423-5.91\"/><path d=\"m5.604 26.616l13.543 10.401l7.423-5.91\"/><path d=\"m5.59 23.948l13.542 10.4l7.423-5.91m-6.32-4.688c-.226 1.027-1.694 1.554-3.278 1.175h0c-1.584-.378-2.685-1.517-2.459-2.545c.226-1.027 1.694-1.553 3.278-1.175s2.685 1.518 2.459 2.545\"/><path d=\"m15.051 15.826l-9.295 5.595l13.331 10.117l7.64-6.015\"/></g></svg>"
                      )
            {
            }
        }
        public class Close : Icon
        {
            public Close()
                : base("Close",
                        IconVariant.Regular,
                        IconSize.Size20,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"20\" height=\"20\" viewBox=\"0 0 32 32\"><path fill=\"#444791\" d=\"M16 2C8.2 2 2 8.2 2 16s6.2 14 14 14s14-6.2 14-14S23.8 2 16 2m0 26C9.4 28 4 22.6 4 16S9.4 4 16 4s12 5.4 12 12s-5.4 12-12 12\"/><path fill=\"#444791\" d=\"M21.4 23L16 17.6L10.6 23L9 21.4l5.4-5.4L9 10.6L10.6 9l5.4 5.4L21.4 9l1.6 1.6l-5.4 5.4l5.4 5.4z\"/></svg>"
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
        public class Projects1 : Icon
        {
            public Projects1()
                : base("Projects1",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Projects2 : Icon
        {
            public Projects2()
                : base("Projects2",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 256 256\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M88 144v-16a8 8 0 0 1 16 0v16a8 8 0 0 1-16 0m40 8a8 8 0 0 0 8-8v-24a8 8 0 0 0-16 0v24a8 8 0 0 0 8 8m32 0a8 8 0 0 0 8-8v-32a8 8 0 0 0-16 0v32a8 8 0 0 0 8 8m56-72v96h8a8 8 0 0 1 0 16h-88v17.38a24 24 0 1 1-16 0V192H32a8 8 0 0 1 0-16h8V80a16 16 0 0 1-16-16V48a16 16 0 0 1 16-16h176a16 16 0 0 1 16 16v16a16 16 0 0 1-16 16m-80 152a8 8 0 1 0-8 8a8 8 0 0 0 8-8M40 64h176V48H40Zm160 16H56v96h144Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Stages : Icon
        {
            public Stages()
                : base("Stages",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Categories : Icon
        {
            public Categories()
                : base("Categories",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m6.76 6l.45.89L7.76 8H12v5H4V6zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8V6zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55M6.76 19l.45.89l.55 1.11H12v5H4v-7zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8v-7zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SubCategories : Icon
        {
            public SubCategories()
                : base("SubCategories",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M20 26h6v2h-6zm0-8h8v2h-8zm0-8h10v2H20zm-5-6h2v24h-2zm-4.414-.041L7 7.249L3.412 3.958L2 5.373L7 10l5-4.627z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Issues : Icon
        {
            public Issues()
                : base("Issues",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 1024 1024\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M464 688a48 48 0 1 0 96 0a48 48 0 1 0-96 0m72-112c4.4 0 8-3.6 8-8V296c0-4.4-3.6-8-8-8h-48c-4.4 0-8 3.6-8 8v272c0 4.4 3.6 8 8 8zm400-188h-59.3c-2.6 0-5 1.2-6.5 3.3L763.7 538.1l-49.9-68.8a7.92 7.92 0 0 0-6.5-3.3H648c-6.5 0-10.3 7.4-6.5 12.7l109.2 150.7a16.1 16.1 0 0 0 26 0l165.8-228.7c3.8-5.3 0-12.7-6.5-12.7m-44 306h-64.2c-5.5 0-10.6 2.9-13.6 7.5a352.2 352.2 0 0 1-49.8 62.2A355.9 355.9 0 0 1 651.1 840a355 355 0 0 1-138.7 27.9c-48.1 0-94.8-9.4-138.7-27.9a355.9 355.9 0 0 1-113.3-76.3A353.1 353.1 0 0 1 184 650.5c-18.6-43.8-28-90.5-28-138.5s9.4-94.7 28-138.5c17.9-42.4 43.6-80.5 76.4-113.2s70.9-58.4 113.3-76.3a355 355 0 0 1 138.7-27.9c48.1 0 94.8 9.4 138.7 27.9c42.4 17.9 80.5 43.6 113.3 76.3c19 19 35.6 39.8 49.8 62.2c2.9 4.7 8.1 7.5 13.6 7.5H892c6 0 9.8-6.3 7.2-11.6C828.8 178.5 684.7 82 517.7 80C278.9 77.2 80.5 272.5 80 511.2C79.5 750.1 273.3 944 512.4 944c169.2 0 315.6-97 386.7-238.4A8 8 0 0 0 892 694\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers1 : Icon
        {
            public Offers1()
                : base("Offers1",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M21 13c.6 0 1.1.2 1.4.6c.4.4.6.9.6 1.4l-8 3l-7-2V7h1.9l7.3 2.7c.5.2.8.6.8 1.1c0 .3-.1.6-.3.8s-.5.4-.9.4H14l-1.7-.7l-.3.9l2 .8zM2 7h4v11H2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers2 : Icon
        {
            public Offers2()
                : base("Offers2",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m20.749 12l1.104-1.908a1 1 0 0 0-.365-1.366l-1.91-1.104v-2.2a1 1 0 0 0-1-1h-2.199l-1.103-1.909a1.008 1.008 0 0 0-.607-.466a.993.993 0 0 0-.759.1L12 3.251l-1.91-1.105a1 1 0 0 0-1.366.366L7.62 4.422H5.421a1 1 0 0 0-1 1v2.199l-1.91 1.104a.998.998 0 0 0-.365 1.367L3.25 12l-1.104 1.908a1.004 1.004 0 0 0 .364 1.367l1.91 1.104v2.199a1 1 0 0 0 1 1h2.2l1.104 1.91a1.01 1.01 0 0 0 .866.5c.174 0 .347-.046.501-.135l1.908-1.104l1.91 1.104a1.001 1.001 0 0 0 1.366-.365l1.103-1.91h2.199a1 1 0 0 0 1-1v-2.199l1.91-1.104a1 1 0 0 0 .365-1.367zM9.499 6.99a1.5 1.5 0 1 1-.001 3.001a1.5 1.5 0 0 1 .001-3.001m.3 9.6l-1.6-1.199l6-8l1.6 1.199zm4.7.4a1.5 1.5 0 1 1 .001-3.001a1.5 1.5 0 0 1-.001 3.001\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Types : Icon
        {
            public Types()
                : base("Types",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M22 17a5 5 0 1 1-10.001-.001A5 5 0 0 1 22 17M6.5 6.5h3.8L7 1L1 11h5.5zm9.5 4.085V8H8v8h2.585A6.505 6.505 0 0 1 16 10.585\" />\r\n</svg>"
                      )
            {
            }
        }
        public class States : Icon
        {
            public States()
                : base("States",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices1 : Icon
        {
            public Invoices1()
                : base("Invoices1",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M4.4 10.2c-.6.1-1.4-.3-1.7-.4l-.5.9s.9.4 1.7.5v.8h1v-.9c.9-.3 1.4-1.1 1.5-1.8c0-.8-.6-1.4-1.9-1.9c-.4-.2-1.1-.5-1.1-.9c0-.5.4-.8 1-.8c.7 0 1.4.3 1.4.3l.4-.9s-.5-.2-1.2-.4V4H4v.7c-.9.2-1.5.8-1.6 1.7c0 1.2 1.3 1.7 1.8 1.9c.6.2 1.3.6 1.3.9c0 .4-.4.9-1.1 1\" />\r\n\t<path fill=\"#444791\" d=\"M0 2v12h16V2zm15 11H1V3h14z\" />\r\n\t<path fill=\"#444791\" d=\"M8 5h6v1H8zm0 2h6v1H8zm0 2h3v1H8z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices2 : Icon
        {
            public Invoices2()
                : base("Invoices2",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M6 3v26h16v-2H8V5h10v6h6v2h2V9.6l-.3-.3l-6-6l-.3-.3zm14 3.4L22.6 9H20zM10 13v2h12v-2zm17 2v2c-1.7.3-3 1.7-3 3.5c0 2 1.5 3.5 3.5 3.5h1c.8 0 1.5.7 1.5 1.5s-.7 1.5-1.5 1.5H25v2h2v2h2v-2c1.7-.3 3-1.7 3-3.5c0-2-1.5-3.5-3.5-3.5h-1c-.8 0-1.5-.7-1.5-1.5s.7-1.5 1.5-1.5H31v-2h-2v-2zm-17 3v2h7v-2zm9 0v2h3v-2zm-9 4v2h7v-2zm9 0v2h3v-2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments1 : Icon
        {
            public Payments1()
                : base("Payments1",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m17.5 16.82l2.44 1.41l-.75 1.3L16 17.69V14h1.5zM24 17c0 3.87-3.13 7-7 7s-7-3.13-7-7c0-.34.03-.67.08-1H2V4h18v6.68c2.36 1.13 4 3.53 4 6.32m-13.32-3c.18-.36.37-.7.6-1.03c-.09.03-.18.03-.28.03c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3c0 .25-.04.5-.1.73c.94-.46 1.99-.73 3.1-.73c.34 0 .67.03 1 .08V8a2 2 0 0 1-2-2H6c0 1.11-.89 2-2 2v4a2 2 0 0 1 2 2zM22 17c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5s5-2.24 5-5\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments2 : Icon
        {
            public Payments2()
                : base("Payments2",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 10a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1zM1 5.5A2.5 2.5 0 0 1 3.5 3h9A2.5 2.5 0 0 1 15 5.5v5a2.5 2.5 0 0 1-2.5 2.5h-9A2.5 2.5 0 0 1 1 10.5zM14 6v-.5A1.5 1.5 0 0 0 12.5 4h-9A1.5 1.5 0 0 0 2 5.5V6zM2 7v3.5A1.5 1.5 0 0 0 3.5 12h9a1.5 1.5 0 0 0 1.5-1.5V7z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines1 : Icon
        {
            public Disciplines1()
                : base("Disciplines1",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\" d=\"M6 18h36v6a6 6 0 0 1-6 6H12a6 6 0 0 1-6-6zm34 24H8m5 0l3-12m19 12l-3-12m-2-12L27 4h-6l-3 14m18-7h4M8 11h4\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines2 : Icon
        {
            public Disciplines2()
                : base("Disciplines2",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<rect width=\"36\" height=\"20\" x=\"6\" y=\"6\" rx=\"2\" />\r\n\t\t<path stroke-linecap=\"round\" d=\"M14 13h8m-8 6h20M8 44l4.889-6h21.778L40 44M24 26v18\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables1 : Icon
        {
            public Deliverables1()
                : base("Deliverables1",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m23 1l-6 6l1.415 1.402L22 4.818V21H10V10H8v11c0 1.103.897 2 2 2h12c1.103 0 2-.897 2-2V4.815l3.586 3.587L29 7z\" />\r\n\t<path fill=\"#444791\" d=\"M18.5 19h-5c-.827 0-1.5-.673-1.5-1.5v-5c0-.827.673-1.5 1.5-1.5h5c.827 0 1.5.673 1.5 1.5v5c0 .827-.673 1.5-1.5 1.5M14 17h4v-4h-4zm2 14v-2c7.168 0 13-5.832 13-13c0-1.265-.181-2.514-.538-3.715l1.917-.57C30.79 13.1 31 14.542 31 16c0 8.271-6.729 15-15 15M1.621 20.285A15.011 15.011 0 0 1 1 16C1 7.729 7.729 1 16 1v2C8.832 3 3 8.832 3 16c0 1.265.181 2.515.538 3.715z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables2 : Icon
        {
            public Deliverables2()
                : base("Deliverables2",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<path d=\"m20 33l6 2s15-3 17-3s2 2 0 4s-9 8-15 8s-10-3-14-3H4\" />\r\n\t\t<path d=\"M4 29c2-2 6-5 10-5s13.5 4 15 6s-3 5-3 5M16 18v-8a2 2 0 0 1 2-2h24a2 2 0 0 1 2 2v16\" />\r\n\t\t<path d=\"M25 8h10v9H25z\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks1 : Icon
        {
            public SupportiveWorks1()
                : base("SupportiveWorks1",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-width=\"2\" d=\"M19 7s-5 7-12.5 7c-2 0-5.5 1-5.5 5v4h11v-4c0-2.5 3-1 7-8l-1.5-1.5M3 5V2h20v14h-3M11 1h4v2h-4zM6.5 14a3.5 3.5 0 1 0 0-7a3.5 3.5 0 0 0 0 7Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks2 : Icon
        {
            public SupportiveWorks2()
                : base("SupportiveWorks2",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M16 32C7.125 32 0 24.776 0 16C0 7.125 7.125 0 16 0s16 7.125 16 16c0 8.776-7.125 16-16 16m0-29.312c-7.328 0-13.318 5.984-13.318 13.313S8.672 29.319 16 29.319c7.328 0 13.318-5.99 13.318-13.318S23.328 2.688 16 2.688m7.849 14.859H12.286a.927.927 0 0 1-.932-.917v-1.349c0-.521.411-.932.932-.932h11.661c.516 0 .927.417.927.932v1.339c-.099.516-.516.927-1.026.927zm-2.995-5.162H9.187a.925.925 0 0 1-.932-.917v-1.349c0-.417.417-.828.932-.828h11.661c.417 0 .828.417.828.828v1.339c0 .516-.411.927-.823.927zm-11.666 7.23h11.667c.516 0 .927.411.927.927v1.339a.928.928 0 0 1-.922.932H9.188c-.516-.104-.927-.516-.927-1.031v-1.344c-.005-.411.411-.823.927-.823\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Documents : Icon
        {
            public Documents()
                : base("Documents",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M40.358 12.581L26.363 6.04a5.74 5.74 0 0 0-4.857-.001l-13.863 6.47a2.295 2.295 0 0 0-.001 4.159l13.995 6.541a5.74 5.74 0 0 0 4.857.002l13.863-6.471a2.295 2.295 0 0 0 .001-4.159\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m13.227 19.278l-5.584 2.606a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.002l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M13.227 28.654L7.643 31.26a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.001l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Download : Icon
        {
            public Download()
                : base("Download",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m12 16l-5-5l1.4-1.45l2.6 2.6V4h2v8.15l2.6-2.6L17 11zm-6 4q-.825 0-1.412-.587T4 18v-3h2v3h12v-3h2v3q0 .825-.587 1.413T18 20z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Contract : Icon
        {
            public Contract()
                : base("Contract",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 36 36\"><path fill=\"#444791\" d=\"M8 8.2h16v1.6H8zm0 8h8.086v1.6H8zm15.378-4H8v1.6h13.779zM12.794 29.072a2.47 2.47 0 0 0 2.194.824h7.804a.7.7 0 0 0 0-1.4h-7.804c-.911-.016-.749-.807-.621-1.052a3.962 3.962 0 0 0 .387-.915a1.183 1.183 0 0 0-.616-1.322a1.899 1.899 0 0 0-2.24.517c-.344.355-.822.898-1.28 1.426c.283-1.109.65-2.532 1.01-3.92a1.315 1.315 0 0 0-.755-1.626a1.425 1.425 0 0 0-1.775.793c-.432.831-3.852 6.562-3.886 6.62a.7.7 0 1 0 1.202.718c.128-.215 2.858-4.788 3.719-6.315c-.648 2.5-1.362 5.282-1.404 5.532a.869.869 0 0 0 .407.969a.92.92 0 0 0 1.106-.224c.126-.114.362-.385.957-1.076a62.093 62.093 0 0 1 1.703-1.921c.218-.23.35-.128.222.098a2.291 2.291 0 0 0-.33 2.274\"/><path fill=\"#444791\" d=\"M28 21.695V32H4V4h24v4.993l1.33-1.33a4.304 4.304 0 0 1 .67-.54V3a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v30a1 1 0 0 0 1 1h26a1 1 0 0 0 1-1V21.427a2.91 2.91 0 0 1-2 .268\"/><path fill=\"#444791\" d=\"m34.128 11.861l-.523-.523a1.898 1.898 0 0 0-.11-2.423a1.956 1.956 0 0 0-2.75.162L18.22 21.6l-.837 3.142a.234.234 0 0 0 .296.294l3.131-.847l11.692-11.692l.494.495a.371.371 0 0 1 0 .525l-4.917 4.917a.8.8 0 0 0 1.132 1.131l4.917-4.917a1.972 1.972 0 0 0 0-2.788\"/></svg>"
                      )
            {
            }
        }
        public class Result : Icon
        {
            public Result()
                : base("Result",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 2048 2048\"><path fill=\"#444791\" d=\"M1664 1792v-128H0v128zm384-1408V256h-128v128zm0 1024v-128h-128v128zm-384 0v-128H0v128zm0-1152H0v128h1664zm0 512V640H0v128z\"/></svg>"
                      )
            {
            }
        }
        public class Save : Icon
        {
            public Save()
                : base("Save",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\"><path fill=\"#444791\" d=\"M2 2h14.414L22 7.586V22H2zm2 2v16h2v-6h12v6h2V8.414L15.586 4H13v4H6V4zm4 0v2h3V4zm8 16v-4H8v4z\"/></svg>"
                      )
            {
            }
        }
        public class Expenses : Icon
        {
            public Expenses()
                : base("Expenses",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 48 48\"><g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m16.517 14.344l7.705-4.8l10.274 8.688v12.566l-5.967 4.836V23.817zm9.541-5.086L31.9 5.646l10.46 7.293l-6.433 4.926m.277 10.748l6.296-5.14m-6.296 2.479l6.296-5.14m-6.296 2.48l6.296-5.14m-6.296 2.48l6.296-5.14\"/><path d=\"m35.314 14.172l2.723-2.077l-1.865-1.247l-1.498 1.131M5.5 31.954l13.543 10.4l7.423-5.91\"/><path d=\"m5.5 29.285l13.543 10.4l7.423-5.91\"/><path d=\"m5.604 26.616l13.543 10.401l7.423-5.91\"/><path d=\"m5.59 23.948l13.542 10.4l7.423-5.91m-6.32-4.688c-.226 1.027-1.694 1.554-3.278 1.175h0c-1.584-.378-2.685-1.517-2.459-2.545c.226-1.027 1.694-1.553 3.278-1.175s2.685 1.518 2.459 2.545\"/><path d=\"m15.051 15.826l-9.295 5.595l13.331 10.117l7.64-6.015\"/></g></svg>"
                      )
            {
            }
        }
        public class Close : Icon
        {
            public Close()
                : base("Close",
                        IconVariant.Regular,
                        IconSize.Size24,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 32 32\"><path fill=\"#444791\" d=\"M16 2C8.2 2 2 8.2 2 16s6.2 14 14 14s14-6.2 14-14S23.8 2 16 2m0 26C9.4 28 4 22.6 4 16S9.4 4 16 4s12 5.4 12 12s-5.4 12-12 12\"/><path fill=\"#444791\" d=\"M21.4 23L16 17.6L10.6 23L9 21.4l5.4-5.4L9 10.6L10.6 9l5.4 5.4L21.4 9l1.6 1.6l-5.4 5.4l5.4 5.4z\"/></svg>"
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
        public class Projects1 : Icon
        {
            public Projects1()
                : base("Projects1",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Projects2 : Icon
        {
            public Projects2()
                : base("Projects2",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 256 256\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M88 144v-16a8 8 0 0 1 16 0v16a8 8 0 0 1-16 0m40 8a8 8 0 0 0 8-8v-24a8 8 0 0 0-16 0v24a8 8 0 0 0 8 8m32 0a8 8 0 0 0 8-8v-32a8 8 0 0 0-16 0v32a8 8 0 0 0 8 8m56-72v96h8a8 8 0 0 1 0 16h-88v17.38a24 24 0 1 1-16 0V192H32a8 8 0 0 1 0-16h8V80a16 16 0 0 1-16-16V48a16 16 0 0 1 16-16h176a16 16 0 0 1 16 16v16a16 16 0 0 1-16 16m-80 152a8 8 0 1 0-8 8a8 8 0 0 0 8-8M40 64h176V48H40Zm160 16H56v96h144Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Stages : Icon
        {
            public Stages()
                : base("Stages",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Categories : Icon
        {
            public Categories()
                : base("Categories",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m6.76 6l.45.89L7.76 8H12v5H4V6zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8V6zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55M6.76 19l.45.89l.55 1.11H12v5H4v-7zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8v-7zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SubCategories : Icon
        {
            public SubCategories()
                : base("SubCategories",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M20 26h6v2h-6zm0-8h8v2h-8zm0-8h10v2H20zm-5-6h2v24h-2zm-4.414-.041L7 7.249L3.412 3.958L2 5.373L7 10l5-4.627z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Issues : Icon
        {
            public Issues()
                : base("Issues",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 1024 1024\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M464 688a48 48 0 1 0 96 0a48 48 0 1 0-96 0m72-112c4.4 0 8-3.6 8-8V296c0-4.4-3.6-8-8-8h-48c-4.4 0-8 3.6-8 8v272c0 4.4 3.6 8 8 8zm400-188h-59.3c-2.6 0-5 1.2-6.5 3.3L763.7 538.1l-49.9-68.8a7.92 7.92 0 0 0-6.5-3.3H648c-6.5 0-10.3 7.4-6.5 12.7l109.2 150.7a16.1 16.1 0 0 0 26 0l165.8-228.7c3.8-5.3 0-12.7-6.5-12.7m-44 306h-64.2c-5.5 0-10.6 2.9-13.6 7.5a352.2 352.2 0 0 1-49.8 62.2A355.9 355.9 0 0 1 651.1 840a355 355 0 0 1-138.7 27.9c-48.1 0-94.8-9.4-138.7-27.9a355.9 355.9 0 0 1-113.3-76.3A353.1 353.1 0 0 1 184 650.5c-18.6-43.8-28-90.5-28-138.5s9.4-94.7 28-138.5c17.9-42.4 43.6-80.5 76.4-113.2s70.9-58.4 113.3-76.3a355 355 0 0 1 138.7-27.9c48.1 0 94.8 9.4 138.7 27.9c42.4 17.9 80.5 43.6 113.3 76.3c19 19 35.6 39.8 49.8 62.2c2.9 4.7 8.1 7.5 13.6 7.5H892c6 0 9.8-6.3 7.2-11.6C828.8 178.5 684.7 82 517.7 80C278.9 77.2 80.5 272.5 80 511.2C79.5 750.1 273.3 944 512.4 944c169.2 0 315.6-97 386.7-238.4A8 8 0 0 0 892 694\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers1 : Icon
        {
            public Offers1()
                : base("Offers1",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M21 13c.6 0 1.1.2 1.4.6c.4.4.6.9.6 1.4l-8 3l-7-2V7h1.9l7.3 2.7c.5.2.8.6.8 1.1c0 .3-.1.6-.3.8s-.5.4-.9.4H14l-1.7-.7l-.3.9l2 .8zM2 7h4v11H2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers2 : Icon
        {
            public Offers2()
                : base("Offers2",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m20.749 12l1.104-1.908a1 1 0 0 0-.365-1.366l-1.91-1.104v-2.2a1 1 0 0 0-1-1h-2.199l-1.103-1.909a1.008 1.008 0 0 0-.607-.466a.993.993 0 0 0-.759.1L12 3.251l-1.91-1.105a1 1 0 0 0-1.366.366L7.62 4.422H5.421a1 1 0 0 0-1 1v2.199l-1.91 1.104a.998.998 0 0 0-.365 1.367L3.25 12l-1.104 1.908a1.004 1.004 0 0 0 .364 1.367l1.91 1.104v2.199a1 1 0 0 0 1 1h2.2l1.104 1.91a1.01 1.01 0 0 0 .866.5c.174 0 .347-.046.501-.135l1.908-1.104l1.91 1.104a1.001 1.001 0 0 0 1.366-.365l1.103-1.91h2.199a1 1 0 0 0 1-1v-2.199l1.91-1.104a1 1 0 0 0 .365-1.367zM9.499 6.99a1.5 1.5 0 1 1-.001 3.001a1.5 1.5 0 0 1 .001-3.001m.3 9.6l-1.6-1.199l6-8l1.6 1.199zm4.7.4a1.5 1.5 0 1 1 .001-3.001a1.5 1.5 0 0 1-.001 3.001\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Types : Icon
        {
            public Types()
                : base("Types",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M22 17a5 5 0 1 1-10.001-.001A5 5 0 0 1 22 17M6.5 6.5h3.8L7 1L1 11h5.5zm9.5 4.085V8H8v8h2.585A6.505 6.505 0 0 1 16 10.585\" />\r\n</svg>"
                      )
            {
            }
        }
        public class States : Icon
        {
            public States()
                : base("States",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices1 : Icon
        {
            public Invoices1()
                : base("Invoices1",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M4.4 10.2c-.6.1-1.4-.3-1.7-.4l-.5.9s.9.4 1.7.5v.8h1v-.9c.9-.3 1.4-1.1 1.5-1.8c0-.8-.6-1.4-1.9-1.9c-.4-.2-1.1-.5-1.1-.9c0-.5.4-.8 1-.8c.7 0 1.4.3 1.4.3l.4-.9s-.5-.2-1.2-.4V4H4v.7c-.9.2-1.5.8-1.6 1.7c0 1.2 1.3 1.7 1.8 1.9c.6.2 1.3.6 1.3.9c0 .4-.4.9-1.1 1\" />\r\n\t<path fill=\"#444791\" d=\"M0 2v12h16V2zm15 11H1V3h14z\" />\r\n\t<path fill=\"#444791\" d=\"M8 5h6v1H8zm0 2h6v1H8zm0 2h3v1H8z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices2 : Icon
        {
            public Invoices2()
                : base("Invoices2",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M6 3v26h16v-2H8V5h10v6h6v2h2V9.6l-.3-.3l-6-6l-.3-.3zm14 3.4L22.6 9H20zM10 13v2h12v-2zm17 2v2c-1.7.3-3 1.7-3 3.5c0 2 1.5 3.5 3.5 3.5h1c.8 0 1.5.7 1.5 1.5s-.7 1.5-1.5 1.5H25v2h2v2h2v-2c1.7-.3 3-1.7 3-3.5c0-2-1.5-3.5-3.5-3.5h-1c-.8 0-1.5-.7-1.5-1.5s.7-1.5 1.5-1.5H31v-2h-2v-2zm-17 3v2h7v-2zm9 0v2h3v-2zm-9 4v2h7v-2zm9 0v2h3v-2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments1 : Icon
        {
            public Payments1()
                : base("Payments1",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m17.5 16.82l2.44 1.41l-.75 1.3L16 17.69V14h1.5zM24 17c0 3.87-3.13 7-7 7s-7-3.13-7-7c0-.34.03-.67.08-1H2V4h18v6.68c2.36 1.13 4 3.53 4 6.32m-13.32-3c.18-.36.37-.7.6-1.03c-.09.03-.18.03-.28.03c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3c0 .25-.04.5-.1.73c.94-.46 1.99-.73 3.1-.73c.34 0 .67.03 1 .08V8a2 2 0 0 1-2-2H6c0 1.11-.89 2-2 2v4a2 2 0 0 1 2 2zM22 17c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5s5-2.24 5-5\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments2 : Icon
        {
            public Payments2()
                : base("Payments2",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 10a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1zM1 5.5A2.5 2.5 0 0 1 3.5 3h9A2.5 2.5 0 0 1 15 5.5v5a2.5 2.5 0 0 1-2.5 2.5h-9A2.5 2.5 0 0 1 1 10.5zM14 6v-.5A1.5 1.5 0 0 0 12.5 4h-9A1.5 1.5 0 0 0 2 5.5V6zM2 7v3.5A1.5 1.5 0 0 0 3.5 12h9a1.5 1.5 0 0 0 1.5-1.5V7z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines1 : Icon
        {
            public Disciplines1()
                : base("Disciplines1",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\" d=\"M6 18h36v6a6 6 0 0 1-6 6H12a6 6 0 0 1-6-6zm34 24H8m5 0l3-12m19 12l-3-12m-2-12L27 4h-6l-3 14m18-7h4M8 11h4\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines2 : Icon
        {
            public Disciplines2()
                : base("Disciplines2",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<rect width=\"36\" height=\"20\" x=\"6\" y=\"6\" rx=\"2\" />\r\n\t\t<path stroke-linecap=\"round\" d=\"M14 13h8m-8 6h20M8 44l4.889-6h21.778L40 44M24 26v18\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables1 : Icon
        {
            public Deliverables1()
                : base("Deliverables1",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m23 1l-6 6l1.415 1.402L22 4.818V21H10V10H8v11c0 1.103.897 2 2 2h12c1.103 0 2-.897 2-2V4.815l3.586 3.587L29 7z\" />\r\n\t<path fill=\"#444791\" d=\"M18.5 19h-5c-.827 0-1.5-.673-1.5-1.5v-5c0-.827.673-1.5 1.5-1.5h5c.827 0 1.5.673 1.5 1.5v5c0 .827-.673 1.5-1.5 1.5M14 17h4v-4h-4zm2 14v-2c7.168 0 13-5.832 13-13c0-1.265-.181-2.514-.538-3.715l1.917-.57C30.79 13.1 31 14.542 31 16c0 8.271-6.729 15-15 15M1.621 20.285A15.011 15.011 0 0 1 1 16C1 7.729 7.729 1 16 1v2C8.832 3 3 8.832 3 16c0 1.265.181 2.515.538 3.715z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables2 : Icon
        {
            public Deliverables2()
                : base("Deliverables2",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<path d=\"m20 33l6 2s15-3 17-3s2 2 0 4s-9 8-15 8s-10-3-14-3H4\" />\r\n\t\t<path d=\"M4 29c2-2 6-5 10-5s13.5 4 15 6s-3 5-3 5M16 18v-8a2 2 0 0 1 2-2h24a2 2 0 0 1 2 2v16\" />\r\n\t\t<path d=\"M25 8h10v9H25z\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks1 : Icon
        {
            public SupportiveWorks1()
                : base("SupportiveWorks1",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-width=\"2\" d=\"M19 7s-5 7-12.5 7c-2 0-5.5 1-5.5 5v4h11v-4c0-2.5 3-1 7-8l-1.5-1.5M3 5V2h20v14h-3M11 1h4v2h-4zM6.5 14a3.5 3.5 0 1 0 0-7a3.5 3.5 0 0 0 0 7Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks2 : Icon
        {
            public SupportiveWorks2()
                : base("SupportiveWorks2",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M16 32C7.125 32 0 24.776 0 16C0 7.125 7.125 0 16 0s16 7.125 16 16c0 8.776-7.125 16-16 16m0-29.312c-7.328 0-13.318 5.984-13.318 13.313S8.672 29.319 16 29.319c7.328 0 13.318-5.99 13.318-13.318S23.328 2.688 16 2.688m7.849 14.859H12.286a.927.927 0 0 1-.932-.917v-1.349c0-.521.411-.932.932-.932h11.661c.516 0 .927.417.927.932v1.339c-.099.516-.516.927-1.026.927zm-2.995-5.162H9.187a.925.925 0 0 1-.932-.917v-1.349c0-.417.417-.828.932-.828h11.661c.417 0 .828.417.828.828v1.339c0 .516-.411.927-.823.927zm-11.666 7.23h11.667c.516 0 .927.411.927.927v1.339a.928.928 0 0 1-.922.932H9.188c-.516-.104-.927-.516-.927-1.031v-1.344c-.005-.411.411-.823.927-.823\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Documents : Icon
        {
            public Documents()
                : base("Documents",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M40.358 12.581L26.363 6.04a5.74 5.74 0 0 0-4.857-.001l-13.863 6.47a2.295 2.295 0 0 0-.001 4.159l13.995 6.541a5.74 5.74 0 0 0 4.857.002l13.863-6.471a2.295 2.295 0 0 0 .001-4.159\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m13.227 19.278l-5.584 2.606a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.002l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M13.227 28.654L7.643 31.26a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.001l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Download : Icon
        {
            public Download()
                : base("Download",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m12 16l-5-5l1.4-1.45l2.6 2.6V4h2v8.15l2.6-2.6L17 11zm-6 4q-.825 0-1.412-.587T4 18v-3h2v3h12v-3h2v3q0 .825-.587 1.413T18 20z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Contract : Icon
        {
            public Contract()
                : base("Contract",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 36 36\"><path fill=\"#444791\" d=\"M8 8.2h16v1.6H8zm0 8h8.086v1.6H8zm15.378-4H8v1.6h13.779zM12.794 29.072a2.47 2.47 0 0 0 2.194.824h7.804a.7.7 0 0 0 0-1.4h-7.804c-.911-.016-.749-.807-.621-1.052a3.962 3.962 0 0 0 .387-.915a1.183 1.183 0 0 0-.616-1.322a1.899 1.899 0 0 0-2.24.517c-.344.355-.822.898-1.28 1.426c.283-1.109.65-2.532 1.01-3.92a1.315 1.315 0 0 0-.755-1.626a1.425 1.425 0 0 0-1.775.793c-.432.831-3.852 6.562-3.886 6.62a.7.7 0 1 0 1.202.718c.128-.215 2.858-4.788 3.719-6.315c-.648 2.5-1.362 5.282-1.404 5.532a.869.869 0 0 0 .407.969a.92.92 0 0 0 1.106-.224c.126-.114.362-.385.957-1.076a62.093 62.093 0 0 1 1.703-1.921c.218-.23.35-.128.222.098a2.291 2.291 0 0 0-.33 2.274\"/><path fill=\"#444791\" d=\"M28 21.695V32H4V4h24v4.993l1.33-1.33a4.304 4.304 0 0 1 .67-.54V3a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v30a1 1 0 0 0 1 1h26a1 1 0 0 0 1-1V21.427a2.91 2.91 0 0 1-2 .268\"/><path fill=\"#444791\" d=\"m34.128 11.861l-.523-.523a1.898 1.898 0 0 0-.11-2.423a1.956 1.956 0 0 0-2.75.162L18.22 21.6l-.837 3.142a.234.234 0 0 0 .296.294l3.131-.847l11.692-11.692l.494.495a.371.371 0 0 1 0 .525l-4.917 4.917a.8.8 0 0 0 1.132 1.131l4.917-4.917a1.972 1.972 0 0 0 0-2.788\"/></svg>"
                      )
            {
            }
        }
        public class Result : Icon
        {
            public Result()
                : base("Result",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 2048 2048\"><path fill=\"#444791\" d=\"M1664 1792v-128H0v128zm384-1408V256h-128v128zm0 1024v-128h-128v128zm-384 0v-128H0v128zm0-1152H0v128h1664zm0 512V640H0v128z\"/></svg>"
                      )
            {
            }
        }
        public class Save : Icon
        {
            public Save()
                : base("Save",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 24 24\"><path fill=\"#444791\" d=\"M2 2h14.414L22 7.586V22H2zm2 2v16h2v-6h12v6h2V8.414L15.586 4H13v4H6V4zm4 0v2h3V4zm8 16v-4H8v4z\"/></svg>"
                      )
            {
            }
        }
        public class Expenses : Icon
        {
            public Expenses()
                : base("Expenses",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 48 48\"><g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m16.517 14.344l7.705-4.8l10.274 8.688v12.566l-5.967 4.836V23.817zm9.541-5.086L31.9 5.646l10.46 7.293l-6.433 4.926m.277 10.748l6.296-5.14m-6.296 2.479l6.296-5.14m-6.296 2.48l6.296-5.14m-6.296 2.48l6.296-5.14\"/><path d=\"m35.314 14.172l2.723-2.077l-1.865-1.247l-1.498 1.131M5.5 31.954l13.543 10.4l7.423-5.91\"/><path d=\"m5.5 29.285l13.543 10.4l7.423-5.91\"/><path d=\"m5.604 26.616l13.543 10.401l7.423-5.91\"/><path d=\"m5.59 23.948l13.542 10.4l7.423-5.91m-6.32-4.688c-.226 1.027-1.694 1.554-3.278 1.175h0c-1.584-.378-2.685-1.517-2.459-2.545c.226-1.027 1.694-1.553 3.278-1.175s2.685 1.518 2.459 2.545\"/><path d=\"m15.051 15.826l-9.295 5.595l13.331 10.117l7.64-6.015\"/></g></svg>"
                      )
            {
            }
        }
        public class Close : Icon
        {
            public Close()
                : base("Close",
                        IconVariant.Regular,
                        IconSize.Size28,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"28\" height=\"28\" viewBox=\"0 0 32 32\"><path fill=\"#444791\" d=\"M16 2C8.2 2 2 8.2 2 16s6.2 14 14 14s14-6.2 14-14S23.8 2 16 2m0 26C9.4 28 4 22.6 4 16S9.4 4 16 4s12 5.4 12 12s-5.4 12-12 12\"/><path fill=\"#444791\" d=\"M21.4 23L16 17.6L10.6 23L9 21.4l5.4-5.4L9 10.6L10.6 9l5.4 5.4L21.4 9l1.6 1.6l-5.4 5.4l5.4 5.4z\"/></svg>"
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
        public class Projects1 : Icon
        {
            public Projects1()
                : base("Projects1",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Projects2 : Icon
        {
            public Projects2()
                : base("Projects2",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 256 256\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M88 144v-16a8 8 0 0 1 16 0v16a8 8 0 0 1-16 0m40 8a8 8 0 0 0 8-8v-24a8 8 0 0 0-16 0v24a8 8 0 0 0 8 8m32 0a8 8 0 0 0 8-8v-32a8 8 0 0 0-16 0v32a8 8 0 0 0 8 8m56-72v96h8a8 8 0 0 1 0 16h-88v17.38a24 24 0 1 1-16 0V192H32a8 8 0 0 1 0-16h8V80a16 16 0 0 1-16-16V48a16 16 0 0 1 16-16h176a16 16 0 0 1 16 16v16a16 16 0 0 1-16 16m-80 152a8 8 0 1 0-8 8a8 8 0 0 0 8-8M40 64h176V48H40Zm160 16H56v96h144Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Stages : Icon
        {
            public Stages()
                : base("Stages",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Categories : Icon
        {
            public Categories()
                : base("Categories",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m6.76 6l.45.89L7.76 8H12v5H4V6zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8V6zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55M6.76 19l.45.89l.55 1.11H12v5H4v-7zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8v-7zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SubCategories : Icon
        {
            public SubCategories()
                : base("SubCategories",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M20 26h6v2h-6zm0-8h8v2h-8zm0-8h10v2H20zm-5-6h2v24h-2zm-4.414-.041L7 7.249L3.412 3.958L2 5.373L7 10l5-4.627z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Issues : Icon
        {
            public Issues()
                : base("Issues",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 1024 1024\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M464 688a48 48 0 1 0 96 0a48 48 0 1 0-96 0m72-112c4.4 0 8-3.6 8-8V296c0-4.4-3.6-8-8-8h-48c-4.4 0-8 3.6-8 8v272c0 4.4 3.6 8 8 8zm400-188h-59.3c-2.6 0-5 1.2-6.5 3.3L763.7 538.1l-49.9-68.8a7.92 7.92 0 0 0-6.5-3.3H648c-6.5 0-10.3 7.4-6.5 12.7l109.2 150.7a16.1 16.1 0 0 0 26 0l165.8-228.7c3.8-5.3 0-12.7-6.5-12.7m-44 306h-64.2c-5.5 0-10.6 2.9-13.6 7.5a352.2 352.2 0 0 1-49.8 62.2A355.9 355.9 0 0 1 651.1 840a355 355 0 0 1-138.7 27.9c-48.1 0-94.8-9.4-138.7-27.9a355.9 355.9 0 0 1-113.3-76.3A353.1 353.1 0 0 1 184 650.5c-18.6-43.8-28-90.5-28-138.5s9.4-94.7 28-138.5c17.9-42.4 43.6-80.5 76.4-113.2s70.9-58.4 113.3-76.3a355 355 0 0 1 138.7-27.9c48.1 0 94.8 9.4 138.7 27.9c42.4 17.9 80.5 43.6 113.3 76.3c19 19 35.6 39.8 49.8 62.2c2.9 4.7 8.1 7.5 13.6 7.5H892c6 0 9.8-6.3 7.2-11.6C828.8 178.5 684.7 82 517.7 80C278.9 77.2 80.5 272.5 80 511.2C79.5 750.1 273.3 944 512.4 944c169.2 0 315.6-97 386.7-238.4A8 8 0 0 0 892 694\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers1 : Icon
        {
            public Offers1()
                : base("Offers1",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M21 13c.6 0 1.1.2 1.4.6c.4.4.6.9.6 1.4l-8 3l-7-2V7h1.9l7.3 2.7c.5.2.8.6.8 1.1c0 .3-.1.6-.3.8s-.5.4-.9.4H14l-1.7-.7l-.3.9l2 .8zM2 7h4v11H2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers2 : Icon
        {
            public Offers2()
                : base("Offers2",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m20.749 12l1.104-1.908a1 1 0 0 0-.365-1.366l-1.91-1.104v-2.2a1 1 0 0 0-1-1h-2.199l-1.103-1.909a1.008 1.008 0 0 0-.607-.466a.993.993 0 0 0-.759.1L12 3.251l-1.91-1.105a1 1 0 0 0-1.366.366L7.62 4.422H5.421a1 1 0 0 0-1 1v2.199l-1.91 1.104a.998.998 0 0 0-.365 1.367L3.25 12l-1.104 1.908a1.004 1.004 0 0 0 .364 1.367l1.91 1.104v2.199a1 1 0 0 0 1 1h2.2l1.104 1.91a1.01 1.01 0 0 0 .866.5c.174 0 .347-.046.501-.135l1.908-1.104l1.91 1.104a1.001 1.001 0 0 0 1.366-.365l1.103-1.91h2.199a1 1 0 0 0 1-1v-2.199l1.91-1.104a1 1 0 0 0 .365-1.367zM9.499 6.99a1.5 1.5 0 1 1-.001 3.001a1.5 1.5 0 0 1 .001-3.001m.3 9.6l-1.6-1.199l6-8l1.6 1.199zm4.7.4a1.5 1.5 0 1 1 .001-3.001a1.5 1.5 0 0 1-.001 3.001\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Types : Icon
        {
            public Types()
                : base("Types",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M22 17a5 5 0 1 1-10.001-.001A5 5 0 0 1 22 17M6.5 6.5h3.8L7 1L1 11h5.5zm9.5 4.085V8H8v8h2.585A6.505 6.505 0 0 1 16 10.585\" />\r\n</svg>"
                      )
            {
            }
        }
        public class States : Icon
        {
            public States()
                : base("States",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices1 : Icon
        {
            public Invoices1()
                : base("Invoices1",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M4.4 10.2c-.6.1-1.4-.3-1.7-.4l-.5.9s.9.4 1.7.5v.8h1v-.9c.9-.3 1.4-1.1 1.5-1.8c0-.8-.6-1.4-1.9-1.9c-.4-.2-1.1-.5-1.1-.9c0-.5.4-.8 1-.8c.7 0 1.4.3 1.4.3l.4-.9s-.5-.2-1.2-.4V4H4v.7c-.9.2-1.5.8-1.6 1.7c0 1.2 1.3 1.7 1.8 1.9c.6.2 1.3.6 1.3.9c0 .4-.4.9-1.1 1\" />\r\n\t<path fill=\"#444791\" d=\"M0 2v12h16V2zm15 11H1V3h14z\" />\r\n\t<path fill=\"#444791\" d=\"M8 5h6v1H8zm0 2h6v1H8zm0 2h3v1H8z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices2 : Icon
        {
            public Invoices2()
                : base("Invoices2",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M6 3v26h16v-2H8V5h10v6h6v2h2V9.6l-.3-.3l-6-6l-.3-.3zm14 3.4L22.6 9H20zM10 13v2h12v-2zm17 2v2c-1.7.3-3 1.7-3 3.5c0 2 1.5 3.5 3.5 3.5h1c.8 0 1.5.7 1.5 1.5s-.7 1.5-1.5 1.5H25v2h2v2h2v-2c1.7-.3 3-1.7 3-3.5c0-2-1.5-3.5-3.5-3.5h-1c-.8 0-1.5-.7-1.5-1.5s.7-1.5 1.5-1.5H31v-2h-2v-2zm-17 3v2h7v-2zm9 0v2h3v-2zm-9 4v2h7v-2zm9 0v2h3v-2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments1 : Icon
        {
            public Payments1()
                : base("Payments1",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m17.5 16.82l2.44 1.41l-.75 1.3L16 17.69V14h1.5zM24 17c0 3.87-3.13 7-7 7s-7-3.13-7-7c0-.34.03-.67.08-1H2V4h18v6.68c2.36 1.13 4 3.53 4 6.32m-13.32-3c.18-.36.37-.7.6-1.03c-.09.03-.18.03-.28.03c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3c0 .25-.04.5-.1.73c.94-.46 1.99-.73 3.1-.73c.34 0 .67.03 1 .08V8a2 2 0 0 1-2-2H6c0 1.11-.89 2-2 2v4a2 2 0 0 1 2 2zM22 17c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5s5-2.24 5-5\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments2 : Icon
        {
            public Payments2()
                : base("Payments2",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 10a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1zM1 5.5A2.5 2.5 0 0 1 3.5 3h9A2.5 2.5 0 0 1 15 5.5v5a2.5 2.5 0 0 1-2.5 2.5h-9A2.5 2.5 0 0 1 1 10.5zM14 6v-.5A1.5 1.5 0 0 0 12.5 4h-9A1.5 1.5 0 0 0 2 5.5V6zM2 7v3.5A1.5 1.5 0 0 0 3.5 12h9a1.5 1.5 0 0 0 1.5-1.5V7z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines1 : Icon
        {
            public Disciplines1()
                : base("Disciplines1",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\" d=\"M6 18h36v6a6 6 0 0 1-6 6H12a6 6 0 0 1-6-6zm34 24H8m5 0l3-12m19 12l-3-12m-2-12L27 4h-6l-3 14m18-7h4M8 11h4\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines2 : Icon
        {
            public Disciplines2()
                : base("Disciplines2",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<rect width=\"36\" height=\"20\" x=\"6\" y=\"6\" rx=\"2\" />\r\n\t\t<path stroke-linecap=\"round\" d=\"M14 13h8m-8 6h20M8 44l4.889-6h21.778L40 44M24 26v18\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables1 : Icon
        {
            public Deliverables1()
                : base("Deliverables1",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m23 1l-6 6l1.415 1.402L22 4.818V21H10V10H8v11c0 1.103.897 2 2 2h12c1.103 0 2-.897 2-2V4.815l3.586 3.587L29 7z\" />\r\n\t<path fill=\"#444791\" d=\"M18.5 19h-5c-.827 0-1.5-.673-1.5-1.5v-5c0-.827.673-1.5 1.5-1.5h5c.827 0 1.5.673 1.5 1.5v5c0 .827-.673 1.5-1.5 1.5M14 17h4v-4h-4zm2 14v-2c7.168 0 13-5.832 13-13c0-1.265-.181-2.514-.538-3.715l1.917-.57C30.79 13.1 31 14.542 31 16c0 8.271-6.729 15-15 15M1.621 20.285A15.011 15.011 0 0 1 1 16C1 7.729 7.729 1 16 1v2C8.832 3 3 8.832 3 16c0 1.265.181 2.515.538 3.715z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables2 : Icon
        {
            public Deliverables2()
                : base("Deliverables2",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<path d=\"m20 33l6 2s15-3 17-3s2 2 0 4s-9 8-15 8s-10-3-14-3H4\" />\r\n\t\t<path d=\"M4 29c2-2 6-5 10-5s13.5 4 15 6s-3 5-3 5M16 18v-8a2 2 0 0 1 2-2h24a2 2 0 0 1 2 2v16\" />\r\n\t\t<path d=\"M25 8h10v9H25z\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks1 : Icon
        {
            public SupportiveWorks1()
                : base("SupportiveWorks1",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-width=\"2\" d=\"M19 7s-5 7-12.5 7c-2 0-5.5 1-5.5 5v4h11v-4c0-2.5 3-1 7-8l-1.5-1.5M3 5V2h20v14h-3M11 1h4v2h-4zM6.5 14a3.5 3.5 0 1 0 0-7a3.5 3.5 0 0 0 0 7Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks2 : Icon
        {
            public SupportiveWorks2()
                : base("SupportiveWorks2",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M16 32C7.125 32 0 24.776 0 16C0 7.125 7.125 0 16 0s16 7.125 16 16c0 8.776-7.125 16-16 16m0-29.312c-7.328 0-13.318 5.984-13.318 13.313S8.672 29.319 16 29.319c7.328 0 13.318-5.99 13.318-13.318S23.328 2.688 16 2.688m7.849 14.859H12.286a.927.927 0 0 1-.932-.917v-1.349c0-.521.411-.932.932-.932h11.661c.516 0 .927.417.927.932v1.339c-.099.516-.516.927-1.026.927zm-2.995-5.162H9.187a.925.925 0 0 1-.932-.917v-1.349c0-.417.417-.828.932-.828h11.661c.417 0 .828.417.828.828v1.339c0 .516-.411.927-.823.927zm-11.666 7.23h11.667c.516 0 .927.411.927.927v1.339a.928.928 0 0 1-.922.932H9.188c-.516-.104-.927-.516-.927-1.031v-1.344c-.005-.411.411-.823.927-.823\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Documents : Icon
        {
            public Documents()
                : base("Documents",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M40.358 12.581L26.363 6.04a5.74 5.74 0 0 0-4.857-.001l-13.863 6.47a2.295 2.295 0 0 0-.001 4.159l13.995 6.541a5.74 5.74 0 0 0 4.857.002l13.863-6.471a2.295 2.295 0 0 0 .001-4.159\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m13.227 19.278l-5.584 2.606a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.002l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M13.227 28.654L7.643 31.26a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.001l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Download : Icon
        {
            public Download()
                : base("Download",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m12 16l-5-5l1.4-1.45l2.6 2.6V4h2v8.15l2.6-2.6L17 11zm-6 4q-.825 0-1.412-.587T4 18v-3h2v3h12v-3h2v3q0 .825-.587 1.413T18 20z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Contract : Icon
        {
            public Contract()
                : base("Contract",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 36 36\"><path fill=\"#444791\" d=\"M8 8.2h16v1.6H8zm0 8h8.086v1.6H8zm15.378-4H8v1.6h13.779zM12.794 29.072a2.47 2.47 0 0 0 2.194.824h7.804a.7.7 0 0 0 0-1.4h-7.804c-.911-.016-.749-.807-.621-1.052a3.962 3.962 0 0 0 .387-.915a1.183 1.183 0 0 0-.616-1.322a1.899 1.899 0 0 0-2.24.517c-.344.355-.822.898-1.28 1.426c.283-1.109.65-2.532 1.01-3.92a1.315 1.315 0 0 0-.755-1.626a1.425 1.425 0 0 0-1.775.793c-.432.831-3.852 6.562-3.886 6.62a.7.7 0 1 0 1.202.718c.128-.215 2.858-4.788 3.719-6.315c-.648 2.5-1.362 5.282-1.404 5.532a.869.869 0 0 0 .407.969a.92.92 0 0 0 1.106-.224c.126-.114.362-.385.957-1.076a62.093 62.093 0 0 1 1.703-1.921c.218-.23.35-.128.222.098a2.291 2.291 0 0 0-.33 2.274\"/><path fill=\"#444791\" d=\"M28 21.695V32H4V4h24v4.993l1.33-1.33a4.304 4.304 0 0 1 .67-.54V3a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v30a1 1 0 0 0 1 1h26a1 1 0 0 0 1-1V21.427a2.91 2.91 0 0 1-2 .268\"/><path fill=\"#444791\" d=\"m34.128 11.861l-.523-.523a1.898 1.898 0 0 0-.11-2.423a1.956 1.956 0 0 0-2.75.162L18.22 21.6l-.837 3.142a.234.234 0 0 0 .296.294l3.131-.847l11.692-11.692l.494.495a.371.371 0 0 1 0 .525l-4.917 4.917a.8.8 0 0 0 1.132 1.131l4.917-4.917a1.972 1.972 0 0 0 0-2.788\"/></svg>"
                      )
            {
            }
        }
        public class Result : Icon
        {
            public Result()
                : base("Result",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 2048 2048\"><path fill=\"#444791\" d=\"M1664 1792v-128H0v128zm384-1408V256h-128v128zm0 1024v-128h-128v128zm-384 0v-128H0v128zm0-1152H0v128h1664zm0 512V640H0v128z\"/></svg>"
                      )
            {
            }
        }
        public class Save : Icon
        {
            public Save()
                : base("Save",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 24 24\"><path fill=\"#444791\" d=\"M2 2h14.414L22 7.586V22H2zm2 2v16h2v-6h12v6h2V8.414L15.586 4H13v4H6V4zm4 0v2h3V4zm8 16v-4H8v4z\"/></svg>"
                      )
            {
            }
        }
        public class Expenses : Icon
        {
            public Expenses()
                : base("Expenses",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 48 48\"><g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m16.517 14.344l7.705-4.8l10.274 8.688v12.566l-5.967 4.836V23.817zm9.541-5.086L31.9 5.646l10.46 7.293l-6.433 4.926m.277 10.748l6.296-5.14m-6.296 2.479l6.296-5.14m-6.296 2.48l6.296-5.14m-6.296 2.48l6.296-5.14\"/><path d=\"m35.314 14.172l2.723-2.077l-1.865-1.247l-1.498 1.131M5.5 31.954l13.543 10.4l7.423-5.91\"/><path d=\"m5.5 29.285l13.543 10.4l7.423-5.91\"/><path d=\"m5.604 26.616l13.543 10.401l7.423-5.91\"/><path d=\"m5.59 23.948l13.542 10.4l7.423-5.91m-6.32-4.688c-.226 1.027-1.694 1.554-3.278 1.175h0c-1.584-.378-2.685-1.517-2.459-2.545c.226-1.027 1.694-1.553 3.278-1.175s2.685 1.518 2.459 2.545\"/><path d=\"m15.051 15.826l-9.295 5.595l13.331 10.117l7.64-6.015\"/></g></svg>"
                      )
            {
            }
        }
        public class Close : Icon
        {
            public Close()
                : base("Close",
                        IconVariant.Regular,
                        IconSize.Size32,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"32\" height=\"32\" viewBox=\"0 0 32 32\"><path fill=\"#444791\" d=\"M16 2C8.2 2 2 8.2 2 16s6.2 14 14 14s14-6.2 14-14S23.8 2 16 2m0 26C9.4 28 4 22.6 4 16S9.4 4 16 4s12 5.4 12 12s-5.4 12-12 12\"/><path fill=\"#444791\" d=\"M21.4 23L16 17.6L10.6 23L9 21.4l5.4-5.4L9 10.6L10.6 9l5.4 5.4L21.4 9l1.6 1.6l-5.4 5.4l5.4 5.4z\"/></svg>"
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
        public class Projects1 : Icon
        {
            public Projects1()
                : base("Projects1",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10h5v-2h-5c-4.34 0-8-3.66-8-8s3.66-8 8-8s8 3.66 8 8v1.43c0 .79-.71 1.57-1.5 1.57s-1.5-.78-1.5-1.57V12c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5c1.38 0 2.64-.56 3.54-1.47c.65.89 1.77 1.47 2.96 1.47c1.97 0 3.5-1.6 3.5-3.57V12c0-5.52-4.48-10-10-10m0 13c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3s-1.34 3-3 3\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Projects2 : Icon
        {
            public Projects2()
                : base("Projects2",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 256 256\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M88 144v-16a8 8 0 0 1 16 0v16a8 8 0 0 1-16 0m40 8a8 8 0 0 0 8-8v-24a8 8 0 0 0-16 0v24a8 8 0 0 0 8 8m32 0a8 8 0 0 0 8-8v-32a8 8 0 0 0-16 0v32a8 8 0 0 0 8 8m56-72v96h8a8 8 0 0 1 0 16h-88v17.38a24 24 0 1 1-16 0V192H32a8 8 0 0 1 0-16h8V80a16 16 0 0 1-16-16V48a16 16 0 0 1 16-16h176a16 16 0 0 1 16 16v16a16 16 0 0 1-16 16m-80 152a8 8 0 1 0-8 8a8 8 0 0 0 8-8M40 64h176V48H40Zm160 16H56v96h144Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Stages : Icon
        {
            public Stages()
                : base("Stages",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Categories : Icon
        {
            public Categories()
                : base("Categories",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m6.76 6l.45.89L7.76 8H12v5H4V6zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8V6zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55M6.76 19l.45.89l.55 1.11H12v5H4v-7zm.62-2H3a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1H9l-.72-1.45a1 1 0 0 0-.9-.55m15.38 2l.45.89l.55 1.11H28v5h-8v-7zm.62-2H19a1 1 0 0 0-1 1v9a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-7a1 1 0 0 0-1-1h-4l-.72-1.45a1 1 0 0 0-.9-.55\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SubCategories : Icon
        {
            public SubCategories()
                : base("SubCategories",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M20 26h6v2h-6zm0-8h8v2h-8zm0-8h10v2H20zm-5-6h2v24h-2zm-4.414-.041L7 7.249L3.412 3.958L2 5.373L7 10l5-4.627z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Issues : Icon
        {
            public Issues()
                : base("Issues",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 1024 1024\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M464 688a48 48 0 1 0 96 0a48 48 0 1 0-96 0m72-112c4.4 0 8-3.6 8-8V296c0-4.4-3.6-8-8-8h-48c-4.4 0-8 3.6-8 8v272c0 4.4 3.6 8 8 8zm400-188h-59.3c-2.6 0-5 1.2-6.5 3.3L763.7 538.1l-49.9-68.8a7.92 7.92 0 0 0-6.5-3.3H648c-6.5 0-10.3 7.4-6.5 12.7l109.2 150.7a16.1 16.1 0 0 0 26 0l165.8-228.7c3.8-5.3 0-12.7-6.5-12.7m-44 306h-64.2c-5.5 0-10.6 2.9-13.6 7.5a352.2 352.2 0 0 1-49.8 62.2A355.9 355.9 0 0 1 651.1 840a355 355 0 0 1-138.7 27.9c-48.1 0-94.8-9.4-138.7-27.9a355.9 355.9 0 0 1-113.3-76.3A353.1 353.1 0 0 1 184 650.5c-18.6-43.8-28-90.5-28-138.5s9.4-94.7 28-138.5c17.9-42.4 43.6-80.5 76.4-113.2s70.9-58.4 113.3-76.3a355 355 0 0 1 138.7-27.9c48.1 0 94.8 9.4 138.7 27.9c42.4 17.9 80.5 43.6 113.3 76.3c19 19 35.6 39.8 49.8 62.2c2.9 4.7 8.1 7.5 13.6 7.5H892c6 0 9.8-6.3 7.2-11.6C828.8 178.5 684.7 82 517.7 80C278.9 77.2 80.5 272.5 80 511.2C79.5 750.1 273.3 944 512.4 944c169.2 0 315.6-97 386.7-238.4A8 8 0 0 0 892 694\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers1 : Icon
        {
            public Offers1()
                : base("Offers1",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M21 13c.6 0 1.1.2 1.4.6c.4.4.6.9.6 1.4l-8 3l-7-2V7h1.9l7.3 2.7c.5.2.8.6.8 1.1c0 .3-.1.6-.3.8s-.5.4-.9.4H14l-1.7-.7l-.3.9l2 .8zM2 7h4v11H2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Offers2 : Icon
        {
            public Offers2()
                : base("Offers2",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m20.749 12l1.104-1.908a1 1 0 0 0-.365-1.366l-1.91-1.104v-2.2a1 1 0 0 0-1-1h-2.199l-1.103-1.909a1.008 1.008 0 0 0-.607-.466a.993.993 0 0 0-.759.1L12 3.251l-1.91-1.105a1 1 0 0 0-1.366.366L7.62 4.422H5.421a1 1 0 0 0-1 1v2.199l-1.91 1.104a.998.998 0 0 0-.365 1.367L3.25 12l-1.104 1.908a1.004 1.004 0 0 0 .364 1.367l1.91 1.104v2.199a1 1 0 0 0 1 1h2.2l1.104 1.91a1.01 1.01 0 0 0 .866.5c.174 0 .347-.046.501-.135l1.908-1.104l1.91 1.104a1.001 1.001 0 0 0 1.366-.365l1.103-1.91h2.199a1 1 0 0 0 1-1v-2.199l1.91-1.104a1 1 0 0 0 .365-1.367zM9.499 6.99a1.5 1.5 0 1 1-.001 3.001a1.5 1.5 0 0 1 .001-3.001m.3 9.6l-1.6-1.199l6-8l1.6 1.199zm4.7.4a1.5 1.5 0 1 1 .001-3.001a1.5 1.5 0 0 1-.001 3.001\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Types : Icon
        {
            public Types()
                : base("Types",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M22 17a5 5 0 1 1-10.001-.001A5 5 0 0 1 22 17M6.5 6.5h3.8L7 1L1 11h5.5zm9.5 4.085V8H8v8h2.585A6.505 6.505 0 0 1 16 10.585\" />\r\n</svg>"
                      )
            {
            }
        }
        public class States : Icon
        {
            public States()
                : base("States",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 20 20\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M3 1a2 2 0 0 0-2 2v3a2 2 0 0 0 2 2h1v-.5q0-.255.035-.5H3a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v1.035A3.5 3.5 0 0 1 7.5 4H8V3a2 2 0 0 0-2-2zm9 16v-1h.5q.255 0 .5-.035V17a1 1 0 0 0 1 1h3a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1h-1.035q.035-.245.035-.5V12h1a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-3a2 2 0 0 1-2-2M5 7.5A2.5 2.5 0 0 1 7.5 5h5A2.5 2.5 0 0 1 15 7.5v5a2.5 2.5 0 0 1-2.5 2.5h-5A2.5 2.5 0 0 1 5 12.5zm2.277-1.484a1.5 1.5 0 0 0-1.26 1.261zM6 10.293L10.293 6H8.708L6 8.708zM11.707 6L6 11.707v.793c0 .232.052.45.146.647l7-7A1.5 1.5 0 0 0 12.5 6zM7.5 14h.793L14 8.294V7.5c0-.232-.053-.45-.146-.647l-7 7c.195.095.414.147.646.147m2.207 0h1.586L14 11.293V9.707zm3.017-.017a1.5 1.5 0 0 0 1.26-1.26z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices1 : Icon
        {
            public Invoices1()
                : base("Invoices1",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M4.4 10.2c-.6.1-1.4-.3-1.7-.4l-.5.9s.9.4 1.7.5v.8h1v-.9c.9-.3 1.4-1.1 1.5-1.8c0-.8-.6-1.4-1.9-1.9c-.4-.2-1.1-.5-1.1-.9c0-.5.4-.8 1-.8c.7 0 1.4.3 1.4.3l.4-.9s-.5-.2-1.2-.4V4H4v.7c-.9.2-1.5.8-1.6 1.7c0 1.2 1.3 1.7 1.8 1.9c.6.2 1.3.6 1.3.9c0 .4-.4.9-1.1 1\" />\r\n\t<path fill=\"#444791\" d=\"M0 2v12h16V2zm15 11H1V3h14z\" />\r\n\t<path fill=\"#444791\" d=\"M8 5h6v1H8zm0 2h6v1H8zm0 2h3v1H8z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Invoices2 : Icon
        {
            public Invoices2()
                : base("Invoices2",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M6 3v26h16v-2H8V5h10v6h6v2h2V9.6l-.3-.3l-6-6l-.3-.3zm14 3.4L22.6 9H20zM10 13v2h12v-2zm17 2v2c-1.7.3-3 1.7-3 3.5c0 2 1.5 3.5 3.5 3.5h1c.8 0 1.5.7 1.5 1.5s-.7 1.5-1.5 1.5H25v2h2v2h2v-2c1.7-.3 3-1.7 3-3.5c0-2-1.5-3.5-3.5-3.5h-1c-.8 0-1.5-.7-1.5-1.5s.7-1.5 1.5-1.5H31v-2h-2v-2zm-17 3v2h7v-2zm9 0v2h3v-2zm-9 4v2h7v-2zm9 0v2h3v-2z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments1 : Icon
        {
            public Payments1()
                : base("Payments1",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m17.5 16.82l2.44 1.41l-.75 1.3L16 17.69V14h1.5zM24 17c0 3.87-3.13 7-7 7s-7-3.13-7-7c0-.34.03-.67.08-1H2V4h18v6.68c2.36 1.13 4 3.53 4 6.32m-13.32-3c.18-.36.37-.7.6-1.03c-.09.03-.18.03-.28.03c-1.66 0-3-1.34-3-3s1.34-3 3-3s3 1.34 3 3c0 .25-.04.5-.1.73c.94-.46 1.99-.73 3.1-.73c.34 0 .67.03 1 .08V8a2 2 0 0 1-2-2H6c0 1.11-.89 2-2 2v4a2 2 0 0 1 2 2zM22 17c0-2.76-2.24-5-5-5s-5 2.24-5 5s2.24 5 5 5s5-2.24 5-5\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Payments2 : Icon
        {
            public Payments2()
                : base("Payments2",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 16 16\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M10.5 10a.5.5 0 0 0 0 1h2a.5.5 0 0 0 0-1zM1 5.5A2.5 2.5 0 0 1 3.5 3h9A2.5 2.5 0 0 1 15 5.5v5a2.5 2.5 0 0 1-2.5 2.5h-9A2.5 2.5 0 0 1 1 10.5zM14 6v-.5A1.5 1.5 0 0 0 12.5 4h-9A1.5 1.5 0 0 0 2 5.5V6zM2 7v3.5A1.5 1.5 0 0 0 3.5 12h9a1.5 1.5 0 0 0 1.5-1.5V7z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines1 : Icon
        {
            public Disciplines1()
                : base("Disciplines1",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\" d=\"M6 18h36v6a6 6 0 0 1-6 6H12a6 6 0 0 1-6-6zm34 24H8m5 0l3-12m19 12l-3-12m-2-12L27 4h-6l-3 14m18-7h4M8 11h4\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Disciplines2 : Icon
        {
            public Disciplines2()
                : base("Disciplines2",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<rect width=\"36\" height=\"20\" x=\"6\" y=\"6\" rx=\"2\" />\r\n\t\t<path stroke-linecap=\"round\" d=\"M14 13h8m-8 6h20M8 44l4.889-6h21.778L40 44M24 26v18\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables1 : Icon
        {
            public Deliverables1()
                : base("Deliverables1",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m23 1l-6 6l1.415 1.402L22 4.818V21H10V10H8v11c0 1.103.897 2 2 2h12c1.103 0 2-.897 2-2V4.815l3.586 3.587L29 7z\" />\r\n\t<path fill=\"#444791\" d=\"M18.5 19h-5c-.827 0-1.5-.673-1.5-1.5v-5c0-.827.673-1.5 1.5-1.5h5c.827 0 1.5.673 1.5 1.5v5c0 .827-.673 1.5-1.5 1.5M14 17h4v-4h-4zm2 14v-2c7.168 0 13-5.832 13-13c0-1.265-.181-2.514-.538-3.715l1.917-.57C30.79 13.1 31 14.542 31 16c0 8.271-6.729 15-15 15M1.621 20.285A15.011 15.011 0 0 1 1 16C1 7.729 7.729 1 16 1v2C8.832 3 3 8.832 3 16c0 1.265.181 2.515.538 3.715z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Deliverables2 : Icon
        {
            public Deliverables2()
                : base("Deliverables2",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"4\">\r\n\t\t<path d=\"m20 33l6 2s15-3 17-3s2 2 0 4s-9 8-15 8s-10-3-14-3H4\" />\r\n\t\t<path d=\"M4 29c2-2 6-5 10-5s13.5 4 15 6s-3 5-3 5M16 18v-8a2 2 0 0 1 2-2h24a2 2 0 0 1 2 2v16\" />\r\n\t\t<path d=\"M25 8h10v9H25z\" />\r\n\t</g>\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks1 : Icon
        {
            public SupportiveWorks1()
                : base("SupportiveWorks1",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-width=\"2\" d=\"M19 7s-5 7-12.5 7c-2 0-5.5 1-5.5 5v4h11v-4c0-2.5 3-1 7-8l-1.5-1.5M3 5V2h20v14h-3M11 1h4v2h-4zM6.5 14a3.5 3.5 0 1 0 0-7a3.5 3.5 0 0 0 0 7Z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class SupportiveWorks2 : Icon
        {
            public SupportiveWorks2()
                : base("SupportiveWorks2",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 32 32\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"M16 32C7.125 32 0 24.776 0 16C0 7.125 7.125 0 16 0s16 7.125 16 16c0 8.776-7.125 16-16 16m0-29.312c-7.328 0-13.318 5.984-13.318 13.313S8.672 29.319 16 29.319c7.328 0 13.318-5.99 13.318-13.318S23.328 2.688 16 2.688m7.849 14.859H12.286a.927.927 0 0 1-.932-.917v-1.349c0-.521.411-.932.932-.932h11.661c.516 0 .927.417.927.932v1.339c-.099.516-.516.927-1.026.927zm-2.995-5.162H9.187a.925.925 0 0 1-.932-.917v-1.349c0-.417.417-.828.932-.828h11.661c.417 0 .828.417.828.828v1.339c0 .516-.411.927-.823.927zm-11.666 7.23h11.667c.516 0 .927.411.927.927v1.339a.928.928 0 0 1-.922.932H9.188c-.516-.104-.927-.516-.927-1.031v-1.344c-.005-.411.411-.823.927-.823\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Documents : Icon
        {
            public Documents()
                : base("Documents",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 48 48\" {...$$props}>\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M40.358 12.581L26.363 6.04a5.74 5.74 0 0 0-4.857-.001l-13.863 6.47a2.295 2.295 0 0 0-.001 4.159l13.995 6.541a5.74 5.74 0 0 0 4.857.002l13.863-6.471a2.295 2.295 0 0 0 .001-4.159\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m13.227 19.278l-5.584 2.606a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.002l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n\t<path fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M13.227 28.654L7.643 31.26a2.295 2.295 0 0 0-.001 4.16l13.995 6.54a5.74 5.74 0 0 0 4.857.001l13.863-6.47a2.295 2.295 0 0 0 .001-4.159l-5.585-2.61\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Download : Icon
        {
            public Download()
                : base("Download",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 24 24\" {...$$props}>\r\n\t<path fill=\"#444791\" d=\"m12 16l-5-5l1.4-1.45l2.6 2.6V4h2v8.15l2.6-2.6L17 11zm-6 4q-.825 0-1.412-.587T4 18v-3h2v3h12v-3h2v3q0 .825-.587 1.413T18 20z\" />\r\n</svg>"
                      )
            {
            }
        }
        public class Contract : Icon
        {
            public Contract()
                : base("Contract",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 36 36\"><path fill=\"#444791\" d=\"M8 8.2h16v1.6H8zm0 8h8.086v1.6H8zm15.378-4H8v1.6h13.779zM12.794 29.072a2.47 2.47 0 0 0 2.194.824h7.804a.7.7 0 0 0 0-1.4h-7.804c-.911-.016-.749-.807-.621-1.052a3.962 3.962 0 0 0 .387-.915a1.183 1.183 0 0 0-.616-1.322a1.899 1.899 0 0 0-2.24.517c-.344.355-.822.898-1.28 1.426c.283-1.109.65-2.532 1.01-3.92a1.315 1.315 0 0 0-.755-1.626a1.425 1.425 0 0 0-1.775.793c-.432.831-3.852 6.562-3.886 6.62a.7.7 0 1 0 1.202.718c.128-.215 2.858-4.788 3.719-6.315c-.648 2.5-1.362 5.282-1.404 5.532a.869.869 0 0 0 .407.969a.92.92 0 0 0 1.106-.224c.126-.114.362-.385.957-1.076a62.093 62.093 0 0 1 1.703-1.921c.218-.23.35-.128.222.098a2.291 2.291 0 0 0-.33 2.274\"/><path fill=\"#444791\" d=\"M28 21.695V32H4V4h24v4.993l1.33-1.33a4.304 4.304 0 0 1 .67-.54V3a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v30a1 1 0 0 0 1 1h26a1 1 0 0 0 1-1V21.427a2.91 2.91 0 0 1-2 .268\"/><path fill=\"#444791\" d=\"m34.128 11.861l-.523-.523a1.898 1.898 0 0 0-.11-2.423a1.956 1.956 0 0 0-2.75.162L18.22 21.6l-.837 3.142a.234.234 0 0 0 .296.294l3.131-.847l11.692-11.692l.494.495a.371.371 0 0 1 0 .525l-4.917 4.917a.8.8 0 0 0 1.132 1.131l4.917-4.917a1.972 1.972 0 0 0 0-2.788\"/></svg>"
                      )
            {
            }
        }
        public class Result : Icon
        {
            public Result()
                : base("Result",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 2048 2048\"><path fill=\"#444791\" d=\"M1664 1792v-128H0v128zm384-1408V256h-128v128zm0 1024v-128h-128v128zm-384 0v-128H0v128zm0-1152H0v128h1664zm0 512V640H0v128z\"/></svg>"
                      )
            {
            }
        }
        public class Save : Icon
        {
            public Save()
                : base("Save",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 24 24\"><path fill=\"#444791\" d=\"M2 2h14.414L22 7.586V22H2zm2 2v16h2v-6h12v6h2V8.414L15.586 4H13v4H6V4zm4 0v2h3V4zm8 16v-4H8v4z\"/></svg>"
                      )
            {
            }
        }
        public class Expenses : Icon
        {
            public Expenses()
                : base("Expenses",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 48 48\"><g fill=\"none\" stroke=\"#444791\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"m16.517 14.344l7.705-4.8l10.274 8.688v12.566l-5.967 4.836V23.817zm9.541-5.086L31.9 5.646l10.46 7.293l-6.433 4.926m.277 10.748l6.296-5.14m-6.296 2.479l6.296-5.14m-6.296 2.48l6.296-5.14m-6.296 2.48l6.296-5.14\"/><path d=\"m35.314 14.172l2.723-2.077l-1.865-1.247l-1.498 1.131M5.5 31.954l13.543 10.4l7.423-5.91\"/><path d=\"m5.5 29.285l13.543 10.4l7.423-5.91\"/><path d=\"m5.604 26.616l13.543 10.401l7.423-5.91\"/><path d=\"m5.59 23.948l13.542 10.4l7.423-5.91m-6.32-4.688c-.226 1.027-1.694 1.554-3.278 1.175h0c-1.584-.378-2.685-1.517-2.459-2.545c.226-1.027 1.694-1.553 3.278-1.175s2.685 1.518 2.459 2.545\"/><path d=\"m15.051 15.826l-9.295 5.595l13.331 10.117l7.64-6.015\"/></g></svg>"
                      )
            {
            }
        }
        public class Close : Icon
        {
            public Close()
                : base("Close",
                        IconVariant.Regular,
                        IconSize.Size48,
                        "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"48\" height=\"48\" viewBox=\"0 0 32 32\"><path fill=\"#444791\" d=\"M16 2C8.2 2 2 8.2 2 16s6.2 14 14 14s14-6.2 14-14S23.8 2 16 2m0 26C9.4 28 4 22.6 4 16S9.4 4 16 4s12 5.4 12 12s-5.4 12-12 12\"/><path fill=\"#444791\" d=\"M21.4 23L16 17.6L10.6 23L9 21.4l5.4-5.4L9 10.6L10.6 9l5.4 5.4L21.4 9l1.6 1.6l-5.4 5.4l5.4 5.4z\"/></svg>"
                      )
            {
            }
        }
    }
}
