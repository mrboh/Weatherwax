(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,WebSharper,Html,Client,Default,ellipsoid,org,Weatherwax,Core,Dependency,AngularExpression1,Dependencies,Services,Enumerator,Utilities,AngularExpression2,Providers,Arrays,PrintfHelpers,String,Seq,Math,Strings,Events;
 Runtime.Define(Global,{
  ellipsoid:{
   org:{
    Weatherwax:{
     Core:{
      AngularExpression0:Runtime.Class({
       Resolve:function(lambda)
       {
        return lambda;
       }
      },{
       New:function()
       {
        return Runtime.New(this,{});
       }
      }),
      AngularExpression1:Runtime.Class({
       Resolve:function(lambda)
       {
        return[this.d1.get_JavascriptName(),lambda];
       }
      },{
       New:function(d1)
       {
        var r;
        r=Runtime.New(this,{});
        r.d1=d1;
        return r;
       }
      }),
      AngularExpression2:Runtime.Class({
       Resolve:function(lambda)
       {
        return[this.d1.get_JavascriptName(),this.d2.get_JavascriptName(),lambda];
       }
      },{
       New:function(d1,d2)
       {
        var r;
        r=Runtime.New(this,{});
        r.d1=d1;
        r.d2=d2;
        return r;
       }
      }),
      AngularExpression3:Runtime.Class({
       Resolve:function(lambda)
       {
        return[this.d1.get_JavascriptName(),this.d2.get_JavascriptName(),this.d3.get_JavascriptName(),lambda];
       }
      },{
       New:function(d1,d2,d3)
       {
        var r;
        r=Runtime.New(this,{});
        r.d1=d1;
        r.d2=d2;
        r.d3=d3;
        return r;
       }
      }),
      AngularExpression4:Runtime.Class({
       Resolve:function(lambda)
       {
        return[this.d1.get_JavascriptName(),this.d2.get_JavascriptName(),this.d3.get_JavascriptName(),this.d4.get_JavascriptName(),lambda];
       }
      },{
       New:function(d1,d2,d3,d4)
       {
        var r;
        r=Runtime.New(this,{});
        r.d1=d1;
        r.d2=d2;
        r.d3=d3;
        r.d4=d4;
        return r;
       }
      }),
      AngularExpression5:Runtime.Class({
       Resolve:function(lambda)
       {
        return[this.d1.get_JavascriptName(),this.d2.get_JavascriptName(),this.d3.get_JavascriptName(),this.d4.get_JavascriptName(),this.d5.get_JavascriptName(),lambda];
       }
      },{
       New:function(d1,d2,d3,d4,d5)
       {
        var r;
        r=Runtime.New(this,{});
        r.d1=d1;
        r.d2=d2;
        r.d3=d3;
        r.d4=d4;
        r.d5=d5;
        return r;
       }
      }),
      ClientDirectives:{
       NgBindHtml:function(x)
       {
        return Default.Attr().NewAttr("ng-bind-html",x);
       },
       NgClass:function(x)
       {
        return Default.Attr().NewAttr("ng-class",x);
       },
       NgController:function(x)
       {
        return Default.Attr().NewAttr("ng-controller",x);
       },
       NgHide:function(x)
       {
        return Default.Attr().NewAttr("ng-hide",x);
       },
       NgHref:function(x)
       {
        return Default.Attr().NewAttr("ng-href",x);
       },
       NgRepeat:function(x)
       {
        return Default.Attr().NewAttr("ng-repeat",x);
       },
       NgShow:function(x)
       {
        return Default.Attr().NewAttr("ng-show",x);
       },
       NgSrc:function(x)
       {
        return Default.Attr().NewAttr("ng-src",x);
       },
       NgView:function(x)
       {
        return Default.Tags().NewTag("ng-view",x);
       },
       SRef:function(x)
       {
        return Default.Attr().NewAttr("ui-sref",x);
       },
       UIView:function(x)
       {
        return Default.Tags().NewTag("ui-view",x);
       }
      },
      Dependencies:{
       Events:{
        StateChangeSuccess:Runtime.Field(function()
        {
         return"$stateChangeSuccess";
        }),
        ViewContentLoaded:Runtime.Field(function()
        {
         return"$viewContentLoaded";
        })
       },
       Other:{
        StateParams:function()
        {
         return Dependency.New("$stateParams");
        }
       },
       Providers:{
        Location:Runtime.Field(function()
        {
         return Dependency.New("$locationProvider");
        }),
        State:Runtime.Field(function()
        {
         return Dependency.New("$stateProvider");
        }),
        UrlMatcherFactory:Runtime.Field(function()
        {
         return Dependency.New("$urlMatcherFactoryProvider");
        }),
        UrlRouter:Runtime.Field(function()
        {
         return Dependency.New("$urlRouterProvider");
        })
       },
       Router:Runtime.Field(function()
       {
        return"ngRoute";
       }),
       Services:{
        CustomScope:function()
        {
         return Dependency.New("$scope");
        },
        Location:Runtime.Field(function()
        {
         return Dependency.New("$location");
        }),
        RootScope:Runtime.Field(function()
        {
         return Dependency.New("$rootScope");
        }),
        Route:Runtime.Field(function()
        {
         return Dependency.New("$route");
        }),
        Sce:Runtime.Field(function()
        {
         return Dependency.New("$sce");
        }),
        Scope:Runtime.Field(function()
        {
         return Dependency.New("$scope");
        }),
        State:Runtime.Field(function()
        {
         return Dependency.New("$state");
        })
       },
       UIRouter:Runtime.Field(function()
       {
        return"ui.router";
       })
      },
      Dependency:Runtime.Class({
       get_JavascriptName:function()
       {
        return this.javascriptName;
       }
      },{
       New:function(javascriptName)
       {
        var r;
        r=Runtime.New(this,{});
        r.javascriptName=javascriptName;
        return r;
       }
      }),
      Utilities:{
       "InjectorService.TransitionToState":function(_this,newState)
       {
        _this.invoke(AngularExpression1.New(Services.State()).Resolve(function(state)
        {
         state.go(newState);
        }));
       },
       "Module.Controller":function(_this,controller)
       {
        _this.controller(controller.get_Name(),controller.get_Implementation());
        return _this;
       },
       "Module.Controllers":function(_this,controllers)
       {
        var enumerator;
        enumerator=Enumerator.Get(controllers);
        while(enumerator.MoveNext())
         {
          Utilities["Module.Controller"](_this,enumerator.get_Current());
         }
        return _this;
       },
       "Module.States":function(_this,stateDefinitions,otherwise,redirects)
       {
        return _this.config(AngularExpression2.New(Providers.State(),Providers.UrlRouter()).Resolve(Runtime.Tupled(function(tupledArg)
        {
         var stateProvider,urlRouterProvider;
         stateProvider=tupledArg[0];
         urlRouterProvider=tupledArg[1];
         Arrays.iter(function(s)
         {
          var matchValue,url,paramLength,baseUrl,matchValue1;
          matchValue=s.Url;
          url=matchValue.$==0?null:matchValue.$0;
          paramLength=s.UrlParametersToPassToTemplate.get_Length();
          baseUrl="/Template/"+PrintfHelpers.toSafe(s.Name)+"/"+Global.String(paramLength)+"/";
          matchValue1=s.ControllerName;
          stateProvider.state(s.Name,{
           url:url,
           templateUrl:paramLength===0?function()
           {
            return baseUrl;
           }:function(o)
           {
            var folder,list;
            folder=function(c)
            {
             return function(p)
             {
              var copyOfStruct;
              copyOfStruct=o[p];
              return c+String(copyOfStruct);
             };
            };
            list=s.UrlParametersToPassToTemplate;
            return Seq.fold(folder,baseUrl,list);
           },
           controller:matchValue1.$==0?null:matchValue1.$0,
           data:s.CustomData
          });
          return;
         },stateDefinitions);
         if(redirects.$==1)
          {
           Arrays.iter(function(r)
           {
            urlRouterProvider.when(r.UrlIn,r.UrlOut);
           },redirects.$0);
          }
         return otherwise.$==0?null:void urlRouterProvider.otherwise(otherwise.$0);
        })));
       }
      },
      WeatherwaxController:Runtime.Class({
       FromSourceFilename:function(f)
       {
        var startIndex,ix,ct;
        startIndex=Math.max(f.lastIndexOf(String.fromCharCode(92)),f.lastIndexOf(String.fromCharCode(47)));
        ix=startIndex+1;
        ct=f.length-Math.max(startIndex,0)-3;
        return Strings.Substring(f,ix,ct);
       }
      },{
       New:function()
       {
        return Runtime.New(this,{});
       }
      })
     }
    }
   }
  }
 });
 Runtime.OnInit(function()
 {
  WebSharper=Runtime.Safe(Global.IntelliFactory.WebSharper);
  Html=Runtime.Safe(WebSharper.Html);
  Client=Runtime.Safe(Html.Client);
  Default=Runtime.Safe(Client.Default);
  ellipsoid=Runtime.Safe(Global.ellipsoid);
  org=Runtime.Safe(ellipsoid.org);
  Weatherwax=Runtime.Safe(org.Weatherwax);
  Core=Runtime.Safe(Weatherwax.Core);
  Dependency=Runtime.Safe(Core.Dependency);
  AngularExpression1=Runtime.Safe(Core.AngularExpression1);
  Dependencies=Runtime.Safe(Core.Dependencies);
  Services=Runtime.Safe(Dependencies.Services);
  Enumerator=Runtime.Safe(WebSharper.Enumerator);
  Utilities=Runtime.Safe(Core.Utilities);
  AngularExpression2=Runtime.Safe(Core.AngularExpression2);
  Providers=Runtime.Safe(Dependencies.Providers);
  Arrays=Runtime.Safe(WebSharper.Arrays);
  PrintfHelpers=Runtime.Safe(WebSharper.PrintfHelpers);
  String=Runtime.Safe(Global.String);
  Seq=Runtime.Safe(WebSharper.Seq);
  Math=Runtime.Safe(Global.Math);
  Strings=Runtime.Safe(WebSharper.Strings);
  return Events=Runtime.Safe(Dependencies.Events);
 });
 Runtime.OnLoad(function()
 {
  Dependencies.UIRouter();
  Services.State();
  Services.Scope();
  Services.Sce();
  Services.Route();
  Services.RootScope();
  Services.Location();
  Dependencies.Router();
  Providers.UrlRouter();
  Providers.UrlMatcherFactory();
  Providers.State();
  Providers.Location();
  Events.ViewContentLoaded();
  Events.StateChangeSuccess();
  return;
 });
}());
