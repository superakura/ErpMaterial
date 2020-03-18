{
    "code": 0
        , "msg": ""
            , "data": [{
                "title": "主页"
                , "icon": "layui-icon-home"
                , "list": [{
                    "title": "控制台"
                    , "jump": "/"
                }, {
                    "name": "OnePage1"
                    , "title": "OnePage1"
                    , "jump": "/Home/OnePage1"
                }, {
                    "name": "OnePage2"
                    , "title": "OnePage2"
                    , "jump": "/Home/OnePage2"
                }, {
                    "name": "计划提报"
                        , "title": "计划提报"
                        , "jump": "/PlanReport/Index"
                }]
            }, {
                "name": "set"
                , "title": "设置"
                , "icon": "layui-icon-set"
                , "list": [{
                    "name": "system"
                    , "title": "系统设置"
                    , "spread": true
                    , "list": [{
                        "name": "website"
                        , "title": "网站设置"
                    }, {
                        "name": "email"
                        , "title": "邮件服务"
                    }]
                }]
            }, {
                "name": "get"
                , "title": "授权"
                , "icon": "layui-icon-auz"
                , "jump": "system/get"
            }]
}