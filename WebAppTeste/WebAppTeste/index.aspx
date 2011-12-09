<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebAppTeste.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.3/jquery.min.js" type="text/javascript"></script>
<%--<script type="text/javascript">
    function parse_str (query_str) {
        var r = {};
        if (query_str) {
            var key_val_pair_list = query_str.split('&');
            var key_val_pair_list_len = key_val_pair_list.length;
            for (var i = 0; i < key_val_pair_list_len; i++) {
                var key_val_pair = key_val_pair_list[i];
                var item = key_val_pair.split("=");
                if (item[1] == undefined || item[1] == "") {
                    r[item[0]] = null;
                }
                else {
                    r[item[0]] = decodeURIComponent(item[1].replace(/\+/g, '%20'));
                }
            }
        }
        return r;
    }

    var qs = parse_str(window.location.search.substring(1, window.location.search.length));
    if (qs.token && window.token) {

    } else if (qs.token) {
        window.token = qs.token;
    } else {
        window.location = "https://www.google.com/accounts/AuthSubRequest?scope=http%3A%2F%2Ffinance.google.com%2Ffinance%2Ffeeds%2F&session=1&secure=0&next=http%3A%2F%2Fwww.underthepixel.com%2Ffinancetest";
    }

</script>--%>
    
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" ID="btnStop" Text="Not initialized" OnClick="eventClick" />
        <asp:Label runat="server" ID="lblMsg" />
    </div>
    </form>
</body>
</html>


<!--
window.kontagent = undefined;
window.kt = undefined;

function setCookie(name, value, minutes) {
    if (minutes) {
        var date = new Date();
        date.setTime(date.getTime() + (minutes * 60000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + ";domain=.atari.com; path=/";
}

function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function deleteCookie(name) {
    setCookie(name, "", -1);
}

function urlencode(str) {
    // http://kevin.vanzonneveld.net
    // +   original by: Philip Peterson
    // +   improved by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
    // +      input by: AJ
    // +   improved by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
    // +   improved by: Brett Zamir (http://brett-zamir.me)
    // +   bugfixed by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
    // +      input by: travc
    // +      input by: Brett Zamir (http://brett-zamir.me)
    // +   bugfixed by: Kevin van Zonneveld (http://kevin.vanzonneveld.net)
    // +   improved by: Lars Fischer
    // +      input by: Ratheous
    // %          note 1: info on what encoding functions to use from: http://xkr.us/articles/javascript/encode-compare/
    // *     example 1: urlencode('Kevin van Zonneveld!');
    // *     returns 1: 'Kevin+van+Zonneveld%21'
    // *     example 2: urlencode('http://kevin.vanzonneveld.net/');
    // *     returns 2: 'http%3A%2F%2Fkevin.vanzonneveld.net%2F'
    // *     example 3: urlencode('http://www.google.nl/search?q=php.js&ie=utf-8&oe=utf-8&aq=t&rls=com.ubuntu:en-US:unofficial&client=firefox-a');
    // *     returns 3: 'http%3A%2F%2Fwww.google.nl%2Fsearch%3Fq%3Dphp.js%26ie%3Dutf-8%26oe%3Dutf-8%26aq%3Dt%26rls%3Dcom.ubuntu%3Aen-US%3Aunofficial%26client%3Dfirefox-a'

    var hash_map = {}, unicodeStr = '', hexEscStr = '';
    var ret = (str + '').toString();

    var replacer = function (search, replace, str) {
        var tmp_arr = [];
        tmp_arr = str.split(search);
        return tmp_arr.join(replace);
    };

    // The hash_map is identical to the one in urldecode.
    hash_map["'"] = '%27';
    hash_map['('] = '%28';
    hash_map[')'] = '%29';
    hash_map['*'] = '%2A';
    hash_map['~'] = '%7E';
    hash_map['!'] = '%21';
    hash_map['%20'] = '+';
    hash_map['\u00DC'] = '%DC';
    hash_map['\u00FC'] = '%FC';
    hash_map['\u00C4'] = '%D4';
    hash_map['\u00E4'] = '%E4';
    hash_map['\u00D6'] = '%D6';
    hash_map['\u00F6'] = '%F6';
    hash_map['\u00DF'] = '%DF';
    hash_map['\u20AC'] = '%80';
    hash_map['\u0081'] = '%81';
    hash_map['\u201A'] = '%82';
    hash_map['\u0192'] = '%83';
    hash_map['\u201E'] = '%84';
    hash_map['\u2026'] = '%85';
    hash_map['\u2020'] = '%86';
    hash_map['\u2021'] = '%87';
    hash_map['\u02C6'] = '%88';
    hash_map['\u2030'] = '%89';
    hash_map['\u0160'] = '%8A';
    hash_map['\u2039'] = '%8B';
    hash_map['\u0152'] = '%8C';
    hash_map['\u008D'] = '%8D';
    hash_map['\u017D'] = '%8E';
    hash_map['\u008F'] = '%8F';
    hash_map['\u0090'] = '%90';
    hash_map['\u2018'] = '%91';
    hash_map['\u2019'] = '%92';
    hash_map['\u201C'] = '%93';
    hash_map['\u201D'] = '%94';
    hash_map['\u2022'] = '%95';
    hash_map['\u2013'] = '%96';
    hash_map['\u2014'] = '%97';
    hash_map['\u02DC'] = '%98';
    hash_map['\u2122'] = '%99';
    hash_map['\u0161'] = '%9A';
    hash_map['\u203A'] = '%9B';
    hash_map['\u0153'] = '%9C';
    hash_map['\u009D'] = '%9D';
    hash_map['\u017E'] = '%9E';
    hash_map['\u0178'] = '%9F';

    // Begin with encodeURIComponent, which most resembles PHP's encoding functions
    ret = encodeURIComponent(ret);

    for (unicodeStr in hash_map) {
        hexEscStr = hash_map[unicodeStr];
        ret = replacer(unicodeStr, hexEscStr, ret); // Custom replace. No regexing
    }

    // Uppercase for full PHP compatibility
    return ret.replace(/(\%([a-z0-9]{2}))/g, function (full, m1, m2) {
        return "%" + m2.toUpperCase();
    });
}



Kontagent.prototype = {
    parse_str: function (query_str) {
        var r = {};
        if (query_str) {
            var key_val_pair_list = query_str.split('&');
            var key_val_pair_list_len = key_val_pair_list.length;
            for (var i = 0; i < key_val_pair_list_len; i++) {
                var key_val_pair = key_val_pair_list[i];
                var item = key_val_pair.split("=");
                if (item[1] == undefined || item[1] == "") {
                    r[item[0]] = null;
                }
                else {
                    r[item[0]] = decodeURIComponent(item[1].replace(/\+/g, '%20'));
                }
            }
        }
        return r;
    },
    send: function (mt, params) {
        serialize = function (obj, prefix) {
            var str = [];
            for (var p in obj) {
                var k = prefix ? prefix + "[" + p + "]" : p, v = obj[p];
                str.push(typeof v == "object" ?
                                serialize(v, k) :
                                encodeURIComponent(k) + "=" + encodeURIComponent(v));
            }
            return str.join("&");
        }

        var getRequest = new Image();
        getRequest.src = this.proxy + mt + "/?" + serialize(params);
    },
    notificationSent: function (uuid, fbid,recipientIDS, st1, st2, st3) {
        var params = {
            u: uuid,
            s: fbid,
            tu: "stream",
            st1: st1
        };

        if (st2) {
            params['st2'] = st2;
        }
        if (st3) {
            params['st3'] = st3;
        }

        this.send("nts", params);
    },
    streamSent: function (uuid, fbid, st1, st2, st3) {
        var params = {
            u: uuid,
            s: fbid,
            tu: "stream",
            st1: st1
        };

        if (st2) {
            params['st2'] = st2;
        }
        if (st3) {
            params['st3'] = st3;
        }

        this.send("pst", params);
    },
    streamClick: function (uuid, fbid, installed, st1, st2, st3) {
        var params = {
            u: uuid,
            r: fbid,
            i: installed,
            tu: "stream",
            st1: st1
        };

        if (st2) {
            params['st2'] = st2;
        }
        if (st3) {
            params['st3'] = st3;
        }

        this.send("psr", params);
        deleteCookie("kt_clicknotsent");
    },
    appAdd: function () {
        var params = {
            s: this.fbid
        };
        if (this.parsed_qs['u'] != undefined) {
            params['u'] = this.parsed_qs['u'];
        } else if (this.parsed_qs['su'] != undefined) {
            this.params['su'] = this.parsed_qs['su'];
        }else{
            var stt = $.md5(getTime());
            this.send("ucc", {
                tu:'direct',
                i:installed,
                st1:"unknown",
                su:stt});
            this.params['su'] = stt;
        }
        this.send("apa", params);
        deleteCookie(this.qs_cookie);
    },
    trackUserInfo: function () {
        if (this.init) {
            var d = new Date();
            this.send('pgr', {s:this.fbid,ts:d.getTime()});
            var user_info_cookie_key = 'kt_capture_user_info_' + this.appId + "_" + this.fbid;
            if (!getCookie(user_info_cookie_key)) {
                if (window.FB){
                    setCookie(user_info_cookie_key, 1, 20160);            
                    var session = FB.getSession();
                    if (session) {
                        var me_json = null;
                        var me_friends_json = null;
                        var this_obj = this;
                        FB.api("/me",
                            function (response) {
                                me_json = response;
                                if (me_json != null && me_friends_json != null) {
                                    this_obj.track_user_info_impl(me_json, me_friends_json);
                                }
                            });
                        FB.api("/me/friends",
                            function (response) {
                                me_friends_json = response;
                                if (me_json != null && me_friends_json != null) {
                                    this_obj.track_user_info_impl(me_json, me_friends_json);
                                }
                            });
                    }
                }
            }
        }
    },
    track_user_info_impl: function (user_info, user_friends_info) {
        var params = { s: user_info['id'] };
        if (user_info['gender'] != undefined) {
            params['g'] = urlencode(user_info['gender'].toUpperCase());
        }
        if (user_info['birthday'] != undefined) {
            var birthday_components = user_info['birthday'].split('/');
            if (birthday_components.length == 3)
                params['b'] = urlencode(birthday_components[2]);
        }
        if (user_friends_info['data'] != undefined) {
            params['f'] = user_friends_info['data'].length;
        }
        this.send('cpu', params);
    },
    trackStreamClick: function (alreadyInstalled) {
        this.streamClick(this.parsed_qs['u'], this.fbid, alreadyInstalled, this.parsed_qs['st1'], this.parsed_qs['st2'], this.parsed_qs['st3']);
    },
    saveQsCookie: function () {
        if (getCookie(this.qs_cookie)) {
            deleteCookie(this.qs_cookie);
        }
        var qs = window.location.search.substring(1, window.location.search.length);
        this.parsed_qs = this.parse_str(qs);
        setCookie(this.qs_cookie, qs, 0);
    }
};

function Kontagent(fbAppId, kontagentUrl) {
    this.proxy = kontagentUrl;
    this.appId = fbAppId;
    this.qs_cookie = 'kt_qs_' + this.appId;
    this.qs = getCookie(this.qs_cookie);
    this.parsed_qs = this.parse_str(this.qs);
    this.init = false;
    if (window.Atari){
        if (Atari._user_info){
            if (Atari._user_info.fbid) {
                this.init = true;
                this.fbid = Atari._user_info.fbid;
            }
        }
    }
}

function flashRequestKontagent(params) {        
    if (kt.init) {
        deleteCookie(kt.qs_cookie);
        window.kt.trackUserInfo();
        if (kt.parsed_qs['mt']) {
            var clicknotsent = getCookie("kt_clicknotsent");
            if (clicknotsent) {
                if (params[0]) {
                    window.kt.trackStreamClick(0);
                } else {
                    window.kt.trackStreamClick(1);
                }
                deleteCookie("kt_clicknotsent");
            }            
        }/*
        if (params[0]) {
            window.kt.appAdd();
        }*/
        document.getElementById("interamaflashContent").sendQsParams(kt.parsed_qs);
    } else {
        document.getElementById("interamaflashContent").sendQsParams(kt.parse_str(window.location.search.substring(1)));
    }
    
}

function publishFeed(sealPublishInfo) {
    var kontagent = {
        u: sealPublishInfo[7],
        st1: sealPublishInfo[8],
        st2: sealPublishInfo[9],
        st3: sealPublishInfo[10],
        svr: sealPublishInfo[11]
    };
    //window.kontagent = kontagent;

    inviteTarget = sealPublishInfo[11] + "redirect.php?redirect=" + sealPublishInfo[0] + '&u=' + kontagent.u + '&st1=' + kontagent.st1 + '&st2=' + kontagent.st2 + '&st3=' + kontagent.st3 + '&tu=stream&mt=psr';
    if (sealPublishInfo[12]) {
        inviteTarget = inviteTarget + "&xt=" + sealPublishInfo[12];
    }
    imgName = sealPublishInfo[3] + sealPublishInfo[5] + '.png';
    
    var publish = {
         method: 'stream.publish',
         display: 'dialog',
         user_message_prompt: sealPublishInfo[1],
         actions: [{ name: 'Claim your bonus', link: inviteTarget }],
         attachment: {
             name: sealPublishInfo[4],
             caption: sealPublishInfo[2],
             href: inviteTarget,
             media: [{ type: 'image', href: inviteTarget, src: imgName}],
             description: sealPublishInfo[6]
         }
    }; 
    
    FB.ui(publish, function (response) {
        var published = false;
        if (response) {
            window.kt.streamSent(kontagent.u, Atari._user_info.fbid, kontagent.st1, kontagent.st2, kontagent.st3);
            published = true;
        }
        document.getElementById("interamaflashContent").publishFinished(published);

    });
}

function inviteFriends(inviteInfo)
{
    Atari.Invites.send
    (
        function(response) { }
    );
}

function embedSWF(atariAppId, serverURL, clientURL, version, fbAppId, facebookMode, KontagentUrl) {
    var flashvars;
    window.mode = "STANDALONE";

    // We have to tell the api our app_id
    Atari._app_id = atariAppId;
    // Calls a function from atari-util.js. This checks if the user is
    // already logged in. If not, will return undefined
    var me = getLoggedUser();
    if (me) {
        if (facebookMode) {
            window.mode = "FB";
        } else {
            window.mode = "ATARI";
        }
        flashvars = {
            id: me.id, // The swf needs to know the user id
            fbid: me.fbid,
            userFirstName: me.displayname,
            userAvatar: me.avatar,
            mode: window.mode, // This mode indicates if we are going to try connecting to atari, facebook or disconnect
            server: serverURL // URL were the .php files are
        };
    } else {
        flashvars = {
            mode: window.mode, // This mode indicates if we are going to try connecting to atari, facebook or disconnect
            server: serverURL // URL were the .php files are
        };
    }

    var params = {
        base: clientURL, // client SWF file root URL
        allowscriptaccess: "always",
        mayscript: "true",
        wmode: "opaque"
    };

    var url = clientURL + "client.swf?v=" + version;
    window.kt = new Kontagent("BGLW57ND8Q8", KontagentUrl);
    swfobject.embedSWF(url, "interamaflashContent", "760", "680", "10.0.0", null, flashvars, params);
}

function getAtariAppFriend() {
    if (window.FB){
        var session = FB.getSession();
        if (session) {
            var friends_fb = null;
            var friends_atari = null;       
            var query = FB.Data.query('SELECT uid FROM user WHERE has_added_app=1 and uid IN (SELECT uid2 FROM friend WHERE uid1 = me())');
            query.wait(function(response) {
                friends_fb = response;
                filter_friends(friends_fb, friends_atari);
            }); 
            Atari.Account.getFriends(function (response) {
                friends_atari = response.friends;
                filter_friends(friends_fb, friends_atari);
            });
        }else{
            Atari.Account.getFriends(function (response) {
                document.getElementById("interamaflashContent").setAtariAppFriend(response.friends);            
            });
        }
    }else{
        Atari.Account.getFriends(function (response) {
            document.getElementById("interamaflashContent").setAtariAppFriend(response.friends);            
        });
    }       
}

function filter_friends(friends_fb, friends_atari){
    if (friends_fb != null && friends_atari != null){
        var filtered_Friends = new Array();
        for (var i in friends_atari){
            var friend = friends_atari[i];
            if (friend.type == "2" || friend.type == "3"){              
                for (var j in friends_fb){              
                    if (friends_fb[j].uid == friend.fbid){
                        filtered_Friends.push(friend);
                        break;
                    }
                }               
            }else{
                filtered_Friends.push(friend);
            }
        }
        document.getElementById("interamaflashContent").setAtariAppFriend(filtered_Friends);
    }
}

function buyAtariToken() {
    Atari.UI.buyTokens(function (response) {
        if (response.code) alert(response.message);
        else Atari._tokens = response.tokens;
    });
}

function getLoggedUser() {
    var user = undefined;
    if (Atari.Account.getInfo()) {
        var uid = Atari._user_info.guid;
        if (uid) {
            user = {
                id: uid,
                fbid: Atari._user_info.fbid,
                avatar: Atari._user_info.avatar
            };
            
            if (Atari._user_info.firstname)
                {
                    user.displayname = Atari._user_info.firstname;
                }else{
                    user.displayname = Atari._user_info.displayname;
                }

            // TODO: remove this workaround when Atari API do it internally
            if (!user.avatar && user.fbid) {
                user.avatar = "http://graph.facebook.com/" + user.fbid + "/picture";
            }
        }
    }
    return user;
}

function getAtariGiftCatalog() {

    Atari.Gifts.getCatalog(function (response) {
        document.getElementById("interamaflashContent").setAtariGiftCatalog(response);
    });
}

function sendAtariGift(args) {

    Atari.Gifts.send(args[0], function (response) {
        document.getElementById("interamaflashContent").sendAtariGiftResult(response);
    });
}

function getAtariGift() {

    Atari.Gifts.getAccepted(function (response) {
        document.getElementById("interamaflashContent").getAtariGiftResult(response);
    });
}

function receiveAtariGiftResult(args) {

    Atari.Gifts.receive(args[0], function () { });
}

function getAtariItemCatalog() {

    Atari.Tokens.getCatalog(function (response) {
        /*
        if (response.code) {
            alert(response.message);
        }
        else {*/
            document.getElementById("interamaflashContent").setAtariItemCatalog(response.catalog);
        //}
    });
}

function requestTokenSpent(args) {
    Atari.Tokens.spendAuthorize(args[0], args[1], args[2], function (response) {
        if (response.code) {
            switch (response.code) {
                case 501:
                    buyAtariToken();
                    break;

                default:
                    // alert(response.message);
                    break;
            }
        }

        document.getElementById("interamaflashContent").autohrizeTokenSpent(response);
    });
}

function requestTokenCapture(args) {
    Atari.Tokens.spendCapture(args[0], args[1], args[2], function (response) {
        /*
        if (response.code) {
            alert(response.message);
            return;
        }
        else {*/
            document.getElementById("interamaflashContent").autohrizeTokenCapture(response);
        //}
    });
}

function requestTokenVoid(args) {
    Atari.Tokens.spendVoid(args[0], args[1], args[2], function (response) {/*
        if (response.code) {
            alert(response.message);
            return;
        }
        else {*/
            document.getElementById("interamaflashContent").autohrizeTokenVoid(response);
        //}
    });
}

function trace(message) {
    alert(message);
}
-->