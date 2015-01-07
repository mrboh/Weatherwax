declare module ellipsoid {
    module org {
        module Weatherwax {
            module Core {
                module ClientDirectives {
                    var NgView : {
                        <_M1>(x: __ABBREV.__WebSharper.seq<_M1>): __ABBREV.__Html.Element;
                    };
                    var UIView : {
                        <_M1>(x: __ABBREV.__WebSharper.seq<_M1>): __ABBREV.__Html.Element;
                    };
                    var NgController : {
                        (x: string): __ABBREV.__Html.IPagelet;
                    };
                    var NgRepeat : {
                        (x: string): __ABBREV.__Html.IPagelet;
                    };
                    var SRef : {
                        (x: string): __ABBREV.__Html.IPagelet;
                    };
                }
                interface Action<_T1> {
                }
                interface WebSharperTemplateBase {
                    Body: __ABBREV.__List.T<any>;
                }
                interface AngularTemplateBase {
                    Content: __ABBREV.__List.T<any>;
                }
                interface ISettings<_T1> {
                    GenerateSnapshot(baseUrl: string, fragment: string): string;
                    TemplateImplementation<_M1>(x0: _T1): __ABBREV.__List.T<any>;
                    get_MainHtmlPath(): string;
                    get_ClientControl(): __ABBREV.__Web.Control;
                    get_TemplateHtmlPath(): string;
                }
                interface AngularWebsite<_T1> {
                }
            }
        }
    }
}
declare module __ABBREV {
    
    export import __WebSharper = IntelliFactory.WebSharper;
    export import __Html = IntelliFactory.WebSharper.Html;
    export import __List = IntelliFactory.WebSharper.List;
    export import __Web = IntelliFactory.WebSharper.Web;
}
