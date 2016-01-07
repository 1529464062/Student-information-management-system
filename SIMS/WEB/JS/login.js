// JavaScript Document
//支持Enter键登录
/*
document.onkeydown = function(e){
if($(".bac").length==0)
{
if(!e) e = window.event;
if((e.keyCode || e.which) == 13){
var obtnLogin=document.getElementById("submit_btn")
obtnLogin.focus();
}
}
}

$(function(){
//提交表单
$('#submit_btn').click(function(){
show_loading();
var myReg = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/; //邮件正则
if($('#email').val() == ''){
show_err_msg('邮箱还没填呢！');	
$('#email').focus();
}else if(!myReg.test($('#email').val())){
show_err_msg('您的邮箱格式错咯！');
$('#email').focus();
}else if($('#password').val() == ''){
show_err_msg('密码还没填呢！');
$('#password').focus();
}else{
//ajax提交表单，#login_form为表单的ID。 如：$('#login_form').ajaxSubmit(function(data) { ... });
show_msg('登录成功咯！  正在为您跳转...','/');	
}
});
});
*/
function updateCaptcha() {
    document.getElementById("captcha_img").src = "Captcha.aspx?" + new Date().getTime();
}
if (document.getElementById("captcha_img")) {
    document.getElementById("captcha_img").addEventListener("click", updateCaptcha);
}
function getUserFlag(){
    if (document.getElementsByName("UserFlag")[0].checked == true) {
        return document.getElementsByName("UserFlag")[0].value;
    } else {
        if (document.getElementsByName("UserFlag")[1].checked == true) {
            return document.getElementsByName("UserFlag")[1].value;
        } 
    }
}
if (document.getElementById("submit_btn")) {
    document.getElementById("submit_btn").addEventListener("click", function() {
        if ($('#email').val() == '') {
            show_err_msg("用户名还没填呢");
        } else {
            if ($('#password').val() == '') {
                show_err_msg('密码还没填呢！');
            } else {
                if ($('#j_captcha').val() == '') {
                    show_err_msg('验证码还没有填！');
                } if (document.getElementsByName("UserFlag")[0].checked != true && document.getElementsByName("UserFlag")[1].checked != true) {
                    show_err_msg('请选择登录身份');
                } else {
                    $.post("Handler/Login.aspx", {
                        "UserName": $('#email').val(),
                        "UserPassword": $('#password').val(),
                        "Captcha": $('#j_captcha').val(),
                        "UserFlag": getUserFlag()
                    },
                    function(response) {
                        if (response == "OK") {
							sessionStorage["UserName"]=$('#email').val();
							sessionStorage["UserFlag"]=getUserFlag();
                            window.location.href = "Html/index.html?UserName=" + $('#email').val() + "&&" + "UserFlag=" + getUserFlag();
                        } else {
                            show_err_msg(response);
                            updateCaptcha();
                        }
                    })
                }
            }
        }
    });
}