(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,WebSharper,Html,Default,Unchecked,Seq,Operators,List,T,ellipsoid,org,Weatherwax,Core,Dependency,Enumerator,Dependencies,Providers,Services;
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
      ClientDirectives:{
       NgController:function(x)
       {
        return Default.Attr().NewAttr("ng-controller",x);
       },
       NgRepeat:function(x)
       {
        return Default.Attr().NewAttr("ng-repeat",x);
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
        return;
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
  Default=Runtime.Safe(Html.Default);
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
  Dependencies=Runtime.Safe(Core.Dependencies);
  Providers=Runtime.Safe(Dependencies.Providers);
  return Services=Runtime.Safe(Dependencies.Services);
 });
 Runtime.OnLoad(function()
 {
  Dependencies.UIRouter();
  Services.State();
  Services.Scope();
  Services.RootScope();
  Dependencies.Router();
  Providers.UrlRouter();
  Providers.UrlMatcherFactory();
  Providers.State();
  Providers.Location();
  return;
 });
}());
