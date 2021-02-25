/*
 Highstock JS v9.0.1 (2021-02-15)

 Indicator series type for Highstock

 (c) 2010-2021 Daniel Studencki

 License: www.highcharts.com/license
*/
(function(a){"object"===typeof module&&module.exports?(a["default"]=a,module.exports=a):"function"===typeof define&&define.amd?define("highcharts/indicators/keltner-channels",["highcharts","highcharts/modules/stock"],function(d){a(d);a.Highcharts=d;return a}):a("undefined"!==typeof Highcharts?Highcharts:void 0)})(function(a){function d(a,e,h,d){a.hasOwnProperty(e)||(a[e]=d.apply(null,h))}a=a?a._modules:{};d(a,"Mixins/MultipleLines.js",[a["Core/Globals.js"],a["Core/Utilities.js"]],function(a,e){var h=
e.defined,d=e.error,w=e.merge,l=a.seriesTypes.sma;return{pointArrayMap:["top","bottom"],pointValKey:"top",linesApiNames:["bottomLine"],getTranslatedLinesNames:function(f){var a=[];(this.pointArrayMap||[]).forEach(function(b){b!==f&&a.push("plot"+b.charAt(0).toUpperCase()+b.slice(1))});return a},toYData:function(f){var a=[];(this.pointArrayMap||[]).forEach(function(b){a.push(f[b])});return a},translate:function(){var a=this,e=a.pointArrayMap,b=[],g;b=a.getTranslatedLinesNames();l.prototype.translate.apply(a,
arguments);a.points.forEach(function(c){e.forEach(function(f,e){g=c[f];null!==g&&(c[b[e]]=a.yAxis.toPixels(g,!0))})})},drawGraph:function(){var a=this,e=a.linesApiNames,b=a.points,g=b.length,c=a.options,x=a.graph,y={options:{gapSize:c.gapSize}},t=[],n;a.getTranslatedLinesNames(a.pointValKey).forEach(function(a,c){for(t[c]=[];g--;)n=b[g],t[c].push({x:n.x,plotX:n.plotX,plotY:n[a],isNull:!h(n[a])});g=b.length});e.forEach(function(b,g){t[g]?(a.points=t[g],c[b]?a.options=w(c[b].styles,y):d('Error: "There is no '+
b+' in DOCS options declared. Check if linesApiNames are consistent with your DOCS line names." at mixin/multiple-line.js:34'),a.graph=a["graph"+b],l.prototype.drawGraph.call(a),a["graph"+b]=a.graph):d('Error: "'+b+" doesn't have equivalent in pointArrayMap. To many elements in linesApiNames relative to pointArrayMap.\"")});a.points=b;a.options=c;a.graph=x;l.prototype.drawGraph.call(a)}}});d(a,"Stock/Indicators/KeltnerChannels/KeltnerChannelsIndicator.js",[a["Mixins/MultipleLines.js"],a["Core/Series/SeriesRegistry.js"],
a["Core/Utilities.js"]],function(a,e,d){var h=this&&this.__extends||function(){var a=function(b,c){a=Object.setPrototypeOf||{__proto__:[]}instanceof Array&&function(a,c){a.__proto__=c}||function(a,c){for(var b in c)c.hasOwnProperty(b)&&(a[b]=c[b])};return a(b,c)};return function(b,c){function d(){this.constructor=b}a(b,c);b.prototype=null===c?Object.create(c):(d.prototype=c.prototype,new d)}}(),r=e.seriesTypes.sma,l=d.correctFloat,f=d.extend,m=d.merge;d=function(a){function b(){var b=null!==a&&a.apply(this,
arguments)||this;b.data=void 0;b.options=void 0;b.points=void 0;return b}h(b,a);b.prototype.init=function(){e.seriesTypes.sma.prototype.init.apply(this,arguments);this.options=m({topLine:{styles:{lineColor:this.color}},bottomLine:{styles:{lineColor:this.color}}},this.options)};b.prototype.getValues=function(a,b){var c=b.period,d=b.periodATR,g=b.multiplierATR,f=a.yData;f=f?f.length:0;var h=[];b=e.seriesTypes.ema.prototype.getValues(a,{period:c,index:b.index});var r=e.seriesTypes.atr.prototype.getValues(a,
{period:d}),m=[],u=[],p;if(!(f<c)){for(p=c;p<=f;p++){var k=b.values[p-c];var q=r.values[p-d];var v=k[0];a=l(k[1]+g*q[1]);q=l(k[1]-g*q[1]);k=k[1];h.push([v,a,k,q]);m.push(v);u.push([a,k,q])}return{values:h,xData:m,yData:u}}};b.defaultOptions=m(r.defaultOptions,{params:{period:20,periodATR:10,multiplierATR:2},bottomLine:{styles:{lineWidth:1,lineColor:void 0}},topLine:{styles:{lineWidth:1,lineColor:void 0}},tooltip:{pointFormat:'<span style="color:{point.color}">\u25cf</span><b> {series.name}</b><br/>Upper Channel: {point.top}<br/>EMA({series.options.params.period}): {point.middle}<br/>Lower Channel: {point.bottom}<br/>'},
marker:{enabled:!1},dataGrouping:{approximation:"averages"},lineWidth:1});return b}(r);f(d.prototype,{pointArrayMap:["top","middle","bottom"],pointValKey:"middle",nameBase:"Keltner Channels",nameComponents:["period","periodATR","multiplierATR"],linesApiNames:["topLine","bottomLine"],requiredIndicators:["ema","atr"],drawGraph:a.drawGraph,getTranslatedLinesNames:a.getTranslatedLinesNames,translate:a.translate,toYData:a.toYData});e.registerSeriesType("keltnerchannels",d);"";return d});d(a,"masters/indicators/keltner-channels.src.js",
[],function(){})});
//# sourceMappingURL=keltner-channels.js.map