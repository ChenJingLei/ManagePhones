/**
 * Created by jf on 2015/9/11.
 */

$(function () {
	 var pageManager = {
        $container: $('.js_container'),
        _pageStack: [],
        _configs: [],
        _defaultPage: null,
        _pageIndex: 1,
        setDefault: function (defaultPage) {
            this._defaultPage = this._find('name', defaultPage);
            return this;
        },
        init: function () {
            var self = this;

            $(window).on('hashchange', function () {
                var state = history.state || {};
                var url = location.hash.indexOf('#') === 0 ? location.hash : '#';
                var page = self._find('url', url) || self._defaultPage;
                if (state._pageIndex <= self._pageIndex || self._findInStack(url)) {
                    self._back(page);
                } else {
                    self._go(page);
                }
            });

            if (history.state && history.state._pageIndex) {
                this._pageIndex = history.state._pageIndex;
            }

            this._pageIndex--;

            var url = location.hash.indexOf('#') === 0 ? location.hash : '#';
            var page = self._find('url', url) || self._defaultPage;
            this._go(page);
            return this;
        },
        push: function (config) {
            this._configs.push(config);
            return this;
        },
        go: function (to) {
            var config = this._find('name', to);
            if (!config) {
                return;
            }
            location.hash = config.url;
        },
        _go: function (config) {
            this._pageIndex ++;

            history.replaceState && history.replaceState({_pageIndex: this._pageIndex}, '', location.href);

            var html = $(config.template).html();
            var $html = $(html).addClass('slideIn').addClass(config.name);
            this.$container.append($html);
            this._pageStack.push({
                config: config,
                dom: $html
            });

            if (!config.isBind) {
                this._bind(config);
            }

            return this;
        },
        back: function () {
            history.back();
        },
        _back: function (config) {
            this._pageIndex --;

            var stack = this._pageStack.pop();
            if (!stack) {
                return;
            }

            var url = location.hash.indexOf('#') === 0 ? location.hash : '#';
            var found = this._findInStack(url);
            if (!found) {
                var html = $(config.template).html();
                var $html = $(html).css('opacity', 1).addClass(config.name);
                $html.insertBefore(stack.dom);

                if (!config.isBind) {
                    this._bind(config);
                }

                this._pageStack.push({
                    config: config,
                    dom: $html
                });
            }

            stack.dom.addClass('slideOut').on('animationend', function () {
                stack.dom.remove();
            }).on('webkitAnimationEnd', function () {
                stack.dom.remove();
            });

            return this;
        },
        _findInStack: function (url) {
            var found = null;
            for(var i = 0, len = this._pageStack.length; i < len; i++){
                var stack = this._pageStack[i];
                if (stack.config.url === url) {
                    found = stack;
                    break;
                }
            }
            return found;
        },
        _find: function (key, value) {
            var page = null;
            for (var i = 0, len = this._configs.length; i < len; i++) {
                if (this._configs[i][key] === value) {
                    page = this._configs[i];
                    break;
                }
            }
            return page;
        },
        _bind: function (page) {
            var events = page.events || {};
            for (var t in events) {
                for (var type in events[t]) {
                    this.$container.on(type, t, events[t][type]);
                }
            }
            page.isBind = true;
        }
    };
	
	var home = {
        name: 'home',
        url: '#',
        template: '#tpl_toast',
        events: {
			'.page':{
				ready:function(e){
					var path = window.location.pathname;
					var page = "";
					if(path.lastIndexOf('.') != -1){
						page = path.substring(6,path.lastIndexOf('.'));
					}else{
						page = path.substring(6);
					}
					switch(page){
						case 'list':
							//home.template = '#tpl_searchbar';
							pageManager.go('searchbar');
						break;
						case 'login':
							//home.template = '#tpl_toast';
							pageManager.go('toast');
						break;
					}
				}
			},
        }
    };
	
	var toast = {
        name: 'toast',
        url: '#toast',
        template: '#tpl_toast',
        events: {
            '#showToast': {
                click: function (e) {
                    var $toast = $('#toast');
                    if ($toast.css('display') != 'none') {
                        return;
                    }

                    $toast.show();
                    setTimeout(function () {
                        $toast.hide();
                    }, 2000);
                }
            },
            '#btnLogin': {
                click: function (e) {
                    var $loadingToast = $('#loadingToast');
                    if ($loadingToast.css('display') != 'none') {
                        return;
                    }

                    $loadingToast.show();
                    setTimeout(function () {
                        $loadingToast.hide();
                    }, 2000);
                }
            }
        }
    };
    var searchbar = {
        name:"searchbar",
		url:"#searchbar",
        template: '#tpl_searchbar',
        events:{
            '#search_input':{
                focus:function(){
                    //searchBar
                    var $weuiSearchBar = $('#search_bar');
                    $weuiSearchBar.addClass('weui_search_focusing');
                },
                blur:function(){
                    var $weuiSearchBar = $('#search_bar');
                    $weuiSearchBar.removeClass('weui_search_focusing');
                    if($(this).val()){
                        $('#search_text').hide();
                    }else{
                        $('#search_text').show();
                    }
					
                },
                input:function(){
                    var $searchShow = $("#search_show");
					$searchShow.children().remove();
                    if($(this).val()){
                        $searchShow.show();
						var xmlHttp = $.ajax(
							{
								type:"post",
								url:"search.php",
								data:{
									info:$(this).val()
								},
								dataType: 'text',
								contentType:'application/x-www-form-urlencoded',
								async:true,
								success: function(data){
									$searchShow.append(data);
								}
							});
							
																						
                    }else{
                        $searchShow.hide();
						function getUrlParam(name) {
            			var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            			var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            			if (r != null) return unescape(r[2]); return null; //返回参数值
        				}	
						$.post("search.php",
							{
								item:"getall",
								c:getUrlParam('c')
							},
							function(data,status){
								$('.container').children("table").replaceWith(data);
							});
							
                    }
                }
            },
			".weui_cell":{
				click:function(){
					 function getUrlParam(name) {
            			var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            			var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            			if (r != null) return unescape(r[2]); return null; //返回参数值
        			}
					$.post("search.php",
							{
								item:$(this).children().children('p').html(),
								c:getUrlParam('c')
							},
							function(data,status){
								$('.container').children("table").replaceWith(data);
							});
					$("#search_show").hide();
				}
			},
            "#search_cancel":{
                touchend:function(){
                    $("#search_show").hide();
                    $('#search_input').val('');
                }
            },
            "#search_clear":{
                touchend:function(){
                    $("#search_show").hide();
                    $('#search_input').val('');
                }
            }
        }
    };
	
	pageManager.push(home)
	 	.push(toast)
	 	.push(searchbar)
        .setDefault('home')
        .init();
});