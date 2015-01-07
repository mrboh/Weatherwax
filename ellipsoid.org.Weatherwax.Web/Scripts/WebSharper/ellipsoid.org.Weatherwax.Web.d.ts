declare module ellipsoid {
    module org {
        module Weatherwax {
            module Web {
                module AngularModules {
                    var SiteletApp : {
                        (): __ABBREV.__SharpAngles.Module;
                    };
                }
                module AngularRouter {
                    interface ErrorRouteParameters {
                        id: number;
                    }
                    var RouteConfiguration : {
                        (): any;
                    };
                }
                module AngularControllers {
                    interface ErrorRouteParameters {
                        id: number;
                    }
                    var BaseController : {
                        (): any;
                    };
                    var HomeController : {
                        (): any;
                    };
                    var AboutController : {
                        (): any;
                    };
                    var MusicController : {
                        (): any;
                    };
                    var ErrorController : {
                        (): any;
                    };
                }
                module AngularConfiguration {
                    var UrlConfiguration : {
                        (): any;
                    };
                    var UIRouterConfiguration : {
                        (): any;
                    };
                }
                module AngularDependencies {
                    var Router : {
                        (): string;
                    };
                    var UIRouter : {
                        (): string;
                    };
                }
                module Remoting {
                    interface Song {
                        Title: string;
                        Artist: string;
                        Album: string;
                        PlayCount: number;
                    }
                }
                module Configuration {
                    var AppName : {
                        (): string;
                    };
                }
                interface AngularTemplate {
                }
            }
        }
    }
}
declare module IntelliFactory {
    module WebSharper {
        interface F2<_T1, _T2, _T3> {
            (a1: _T1, a2: _T2): _T3;
            (tuple: {
                0: _T1;
                1: _T2;
            }): _T3;
        }
    }
}
declare module __ABBREV {
    
    export import __SharpAngles = ellipsoid.org.SharpAngles;
}
