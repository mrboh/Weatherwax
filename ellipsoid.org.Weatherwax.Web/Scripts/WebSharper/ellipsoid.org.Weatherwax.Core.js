(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,WebSharper,Html,Client,Default,Unchecked,Seq,Operators,List,T,ellipsoid,org,Weatherwax,Core,Dependency,Enumerator,PrintfHelpers,AngularExpression2,Dependencies,Providers,Services;
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
      ControllerConfiguration:Runtime.Class({
       ControllerName:function(controller)
       {
        var p,l,matchValue;
        p=function(c)
        {
         return Unchecked.Equals(c.Controller,controller);
        };
        l=this._controllers;
        matchValue=Seq.tryFind(p,l);
        return matchValue.$==0?Operators.FailWith("Controller not defined in ControllerConfiguration"):matchValue.$0.Name;
       },
       DefineController:function(controller,name,implementation)
       {
        var p,l;
        p=function(c)
        {
         return Unchecked.Equals(c.Controller,controller);
        };
        l=this._controllers;
        if(Seq.tryFind(p,l).$==0)
         {
          this._controllers=List.append(List.ofArray([{
           Controller:controller,
           Name:name,
           Implementation:implementation
          }]),this._controllers);
         }
        else
         {
          Operators.FailWith("Controller has already been defined");
         }
        return this;
       },
       get_Controllers:function()
       {
        return this._controllers;
       }
      },{
       New:function()
       {
        var r;
        r=Runtime.New(this,{});
        r._controllers=Runtime.New(T,{
         $:0
        });
        return r;
       }
      }),
      Dependencies:{
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
        RootScope:Runtime.Field(function()
        {
         return Dependency.New("$rootScope");
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
      State:Runtime.Class({
       get_Controller:function()
       {
        return this["Controller@"];
       },
       get_Template:function()
       {
        return this["Template@"];
       },
       get_Url:function()
       {
        return this["Url@"];
       }
      },{
       New:function(url,template,controller)
       {
        var r;
        r=Runtime.New(this,{});
        r["Url@"]=url;
        r["Template@"]=template;
        r["Controller@"]=controller;
        return r;
       }
      }),
      StateConfiguration:Runtime.Class({
       DefineState:function(state,implementation)
       {
        var name,p,l;
        name=this.nameMapper.call(null,state);
        p=function(s)
        {
         return s.Name===name;
        };
        l=this._states;
        if(Seq.tryFind(p,l).$==0)
         {
          this._states=List.append(List.ofArray([{
           State:state,
           Name:name,
           Implementation:implementation
          }]),this._states);
         }
        else
         {
          Operators.FailWith("State has already been defined");
         }
        return this;
       },
       Otherwise:function()
       {
        return this._otherwise;
       },
       Otherwise1:function(path)
       {
        this._otherwise={
         $:1,
         $0:path
        };
        return this;
       },
       When:function(whenPath,toPath)
       {
        this._whens=List.append(List.ofArray([[whenPath,toPath]]),this._whens);
        return this;
       },
       get_States:function()
       {
        return this._states;
       },
       get_Whens:function()
       {
        return this._whens;
       }
      },{
       New:function(nameMapper)
       {
        var r;
        r=Runtime.New(this,{});
        r.nameMapper=nameMapper;
        r._states=Runtime.New(T,{
         $:0
        });
        r._whens=Runtime.New(T,{
         $:0
        });
        r._otherwise={
         $:0
        };
        return r;
       }
      }),
      Utilities:{
       "Module.Controllers":function(_this,config)
       {
        var inputSequence,enumerator,c;
        inputSequence=config.get_Controllers();
        enumerator=Enumerator.Get(inputSequence);
        while(enumerator.MoveNext())
         {
          c=enumerator.get_Current();
          _this.controller(c.Name,c.Implementation);
         }
        return _this;
       },
       "Module.States":function(_this,config,nameMapper,templateRelativePath,controllerConfig)
       {
        var resolveTemplate,controllerName;
        resolveTemplate=function(t)
        {
         return t.$==1?t.$0:"Template/"+PrintfHelpers.toSafe(templateRelativePath(t.$0));
        };
        controllerName=function(c)
        {
         return controllerConfig.ControllerName(c);
        };
        return _this.config(AngularExpression2.New(Providers.State(),Providers.UrlRouter()).Resolve(Runtime.Tupled(function(tupledArg)
        {
         var stateProvider,urlRouterProvider,x,action,x1,action1,matchValue3;
         stateProvider=tupledArg[0];
         urlRouterProvider=tupledArg[1];
         x=config.get_States();
         action=function(s)
         {
          var matchValue,matchValue1,c,u,matchValue2,c1;
          matchValue=s.Implementation.get_Url();
          if(matchValue.$==0)
           {
            matchValue1=s.Implementation.get_Controller();
            if(matchValue1.$==0)
             {
              stateProvider.state(s.Name,{
               "abstract":true,
               templateUrl:resolveTemplate(s.Implementation.get_Template()),
               data:s.Implementation
              });
              return;
             }
            else
             {
              c=matchValue1.$0;
              stateProvider.state(s.Name,{
               "abstract":true,
               templateUrl:resolveTemplate(s.Implementation.get_Template()),
               controller:controllerName(c),
               data:s.Implementation
              });
              return;
             }
           }
          else
           {
            u=matchValue.$0;
            matchValue2=s.Implementation.get_Controller();
            if(matchValue2.$==0)
             {
              stateProvider.state(s.Name,{
               url:u,
               templateUrl:resolveTemplate(s.Implementation.get_Template()),
               data:s.Implementation
              });
              return;
             }
            else
             {
              c1=matchValue2.$0;
              stateProvider.state(s.Name,{
               url:u,
               templateUrl:resolveTemplate(s.Implementation.get_Template()),
               controller:controllerName(c1),
               data:s.Implementation
              });
              return;
             }
           }
         };
         Seq.iter(action,x);
         x1=config.get_Whens();
         action1=Runtime.Tupled(function(w)
         {
          urlRouterProvider.when(w[0],w[1]);
         });
         Seq.iter(action1,x1);
         matchValue3=config.Otherwise();
         return matchValue3.$==0?null:void urlRouterProvider.otherwise(matchValue3.$0);
        })));
       }
      }
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
  Unchecked=Runtime.Safe(WebSharper.Unchecked);
  Seq=Runtime.Safe(WebSharper.Seq);
  Operators=Runtime.Safe(WebSharper.Operators);
  List=Runtime.Safe(WebSharper.List);
  T=Runtime.Safe(List.T);
  ellipsoid=Runtime.Safe(Global.ellipsoid);
  org=Runtime.Safe(ellipsoid.org);
  Weatherwax=Runtime.Safe(org.Weatherwax);
  Core=Runtime.Safe(Weatherwax.Core);
  Dependency=Runtime.Safe(Core.Dependency);
  Enumerator=Runtime.Safe(WebSharper.Enumerator);
  PrintfHelpers=Runtime.Safe(WebSharper.PrintfHelpers);
  AngularExpression2=Runtime.Safe(Core.AngularExpression2);
  Dependencies=Runtime.Safe(Core.Dependencies);
  Providers=Runtime.Safe(Dependencies.Providers);
  return Services=Runtime.Safe(Dependencies.Services);
 });
 Runtime.OnLoad(function()
 {
  Dependencies.UIRouter();
  Services.State();
  Services.Scope();
  Services.Sce();
  Services.RootScope();
  Dependencies.Router();
  Providers.UrlRouter();
  Providers.UrlMatcherFactory();
  Providers.State();
  Providers.Location();
  return;
 });
}());
