var UserFlag = "";
var UserName = "";
var StudentInfo; //存储学生详细信息
function getNowFormatDate() {
    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
		 + " " + date.getHours() + seperator2 + date.getMinutes()
		 + seperator2 + date.getSeconds();
    return currentdate;
}
window.onresize = function() {
    document.getElementById("main").style.height = (document.body.offsetHeight - 185) + "px";
}
function StudentQuery() {
    $.get("../Handler/studentInfoSelect.aspx", {
        "StudentId": UserName
    },
		function(data) {
		    var JsonData = JSON.parse(data);
		    document.getElementById("studentInfoSelect_StudentId").innerHTML = JsonData[0].StudentId;
		    document.getElementById("studentInfoSelect_StudentName").innerHTML = JsonData[0].StudentName;
		    document.getElementById("studentInfoSelect_StudentNation").innerHTML = JsonData[0].StudentNation;
		    document.getElementById("studentInfoSelect_StudentTelehpone").innerHTML = JsonData[0].StudentTelehpone;
		    document.getElementById("studentInfoSelect_StudentQQ").innerHTML = JsonData[0].StudentQQ;
		    document.getElementById("studentInfoSelect_StudentClass").innerHTML = JsonData[0].StudentClass;
		    document.getElementById("studentInfoSelect_StudentDormitory").innerHTML = JsonData[0].StudentDormitory;
		    document.getElementById("studentInfoSelect_StudentPhoto").src = JsonData[0].StudentPhoto;
		})
}
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}
function mainChildrenHide() {
    for (var i = 0; i < document.getElementById("main").children.length; i++) {
        document.getElementById("main").children[i].style.display = "none";
    }
}
var CourseInfoManager_startIndex = 0;
var CourseInfoManager_endIndex = 10;
var CourseInfoManager_nowPage = 1;
window.onload = function() {
    window.onresize();
    //判断UserFlag是否存在
    if (sessionStorage["UserName"] && sessionStorage["UserFlag"]) {
        //mainChildrenHide();
        UserFlag = sessionStorage["UserFlag"];
        UserName = sessionStorage["UserName"];
        if (GetQueryString("UserFlag") == "0") {
            document.getElementById("UserName").innerHTML = "[学生]" + UserName;
        } else {
            if (GetQueryString("UserFlag") == "1") {
                document.getElementById("UserName").innerHTML = "[管理员]" + UserName;
            }
        }
        for (var i = 0; i < document.getElementById("nav_dot").getElementsByTagName("li").length; i++) {
            if (document.getElementById("nav_dot").getElementsByTagName("li")[i].getAttribute("data-userflag") != "") {
                if (document.getElementById("nav_dot").getElementsByTagName("li")[i].getAttribute("data-userflag") != UserFlag) {
                    document.getElementById("nav_dot").getElementsByTagName("li")[i].style.display = "none";
                }
            }
            for (var j = 0; j < document.getElementById("nav_dot").getElementsByTagName("li")[i].getElementsByTagName("a").length; j++) {
                if (document.getElementById("nav_dot").getElementsByTagName("li")[i].getElementsByTagName("a")[j].getAttribute("data-userflag") != "") {
                    if (document.getElementById("nav_dot").getElementsByTagName("li")[i].getElementsByTagName("a")[j].getAttribute("data-userflag") != UserFlag) {
                        document.getElementById("nav_dot").getElementsByTagName("li")[i].getElementsByTagName("a")[j].style.display = "none";
                    }
                }
            }
        }
        //点击修改密码
        document.getElementById("updatePassword_Control").addEventListener("click", function() {
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">修改密码</a></li></ul>";
            //显示密码修改页面
            //将站点地图改为密码修改
            mainChildrenHide();
            document.getElementById("updatePassword").style.display = "block";
            document.getElementById("updatePassword_submit").addEventListener("click", function() {
                if ($('#updatePassword_Password').val() != '') {
                    if ($('#updatePassword_NewPassword').val() != '') {
                        if ($('#updatePassword_ConfirmPassword').val() != '') {
                            if ($('#updatePassword_NewPassword').val() == $('#updatePassword_ConfirmPassword').val()) {
                                $.post("../Handler/updatePassword.aspx", {
                                    "UserName": UserName,
                                    "UserPassword": $('#updatePassword_Password').val(),
                                    "NewUserPassword": $('#updatePassword_NewPassword').val(),
                                    "UserFlag": UserFlag
                                },
									function(response) {
									    if (response == "OK") {
									        show_msg("修改成功，请重新登录", "../login.html");
									    } else {
									        show_err_msg(response);
									    }
									    document.getElementById("updatePassword_Password").value = "";
									    document.getElementById("updatePassword_NewPassword").value = "";
									    document.getElementById("updatePassword_ConfirmPassword").value = "";
									});
                            } else {
                                show_err_msg("新密码与确认密码不一致，请重新输入");
                            }
                        } else {
                            show_err_msg("原密码还没有填!");
                            document.getElementById("updatePassword_ConfirmPassword").focus();
                        }
                    } else {
                        show_err_msg("新密码还没有填!");
                        document.getElementById("updatePassword_NewPassword").focus();
                    }
                } else {
                    show_err_msg("原密码还没有填!");
                    document.getElementById("updatePassword_Password").focus();
                }
            });
        });
        //点击退出按钮
        document.getElementById("exit").addEventListener("click", function() {
            //跳转到登录页
            location.href = "../login.html";
            sessionStorage["UserFlag"] = null;
            sessionStorage["UserName"] = null;
        });
        //点击设置按钮
        document.getElementById("Set").addEventListener("click", function() {
            //将站点地图改为设置
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">设置</a></li></ul>";
            mainChildrenHide();
            if (UserFlag == 0) {
                StudentQuery();
                document.getElementById("studentInfoSelect").style.display = "block";
            } else {
                if (UserFlag == 1) {
                    document.getElementById("Admin_userInfoSelect").style.display = "block";
                } else {
                    show_err_msg("用户身份不正确，稍后退出");
                    location.href = "../login.html";
                }
            }

        });
        //<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">系统公告</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">最新公告</a></li></ul>;
        //点击学生信息录入
        document.getElementById("studentInfoInsert_Control").addEventListener("click", function() {
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">学生管理</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">学生信息录入</a></li></ul>";
            mainChildrenHide();
            studentInfoInsert_Control_Init = function() {
                document.getElementById("studentInfoInsert_StudentId").value = "";
                document.getElementById("studentInfoInsert_StudentPassword").value = "123";
                document.getElementById("studentInfoInsert_StudentName").value = "";
                document.getElementById("studentInfoInsert_StudentPhoto").src = "";
                document.getElementById("studentInfoInsert_StudentSex").value = "";
                document.getElementById("studentInfoInsert_StudentNation").value = "";
                document.getElementById("studentInfoInsert_StudentTelehpone").value = "";
                document.getElementById("studentInfoInsert_StudentQQ").value = "";
                document.getElementById("studentInfoInsert_StudentClass").value = "";
                document.getElementById("studentInfoInsert_StudentDormitory").value = "";
                //document.getElementById("studentInfoInsert_StudentAddress").value = "";
                document.getElementById("file").value = "";
            };
            $(function() {
                var options = {
                    success: function(data) {
                        // $("#responseText").text(data);
                    document.getElementById("studentInfoInsert_StudentPhoto").src = data;
                    document.getElementById("studentInfoInsert_StudentPhoto").setAttribute("data-src",data);
                    }
                };

                $("#form1").ajaxForm(options);
            });
            document.getElementById("studentInfoInsert").style.display = "block";
            if (document.getElementById("studentInfoInsert_Add")) {
            var jiaoyan=function() {
                        if (document.getElementById("studentInfoInsert_StudentId").value.trim() != "") {
                            if (document.getElementById("studentInfoInsert_StudentPassword").value.trim() != "") {
                                if (document.getElementById("studentInfoInsert_StudentName").value.trim() != "") {
                                    if (document.getElementById("studentInfoInsert_StudentPhoto").getAttribute("data-src") != "") {
                                        if (document.getElementById("studentInfoInsert_StudentSex").value.trim() != "") {
                                            if (document.getElementById("studentInfoInsert_StudentNation").value.trim() != "") {
                                                if (document.getElementById("studentInfoInsert_StudentTelehpone").value.trim() != "") {
                                                    if (document.getElementById("studentInfoInsert_StudentQQ").value.trim() != "") {
                                                        if (document.getElementById("studentInfoInsert_StudentClass").value.trim() != "") {
                                                            if (document.getElementById("studentInfoInsert_StudentDormitory").value.trim() != "") {
                                                                var loc_province = document.getElementById("loc_province");
                                                                if (getSelectedValue(loc_province) != "") {
                                                                    return true;
                                                                } else {
                                                                    show_err_msg("学生家庭地址没有填");
                                                                    return false;
                                                                }
                                                            } else {
                                                                show_err_msg("学生宿舍没有填");
                                                                return false;
                                                            }
                                                        } else {
                                                            show_err_msg("学生班级没有填");
                                                            return false;
                                                        }
                                                    } else {
                                                        show_err_msg("学生QQ号没有填");
                                                        return false;
                                                    }
                                                } else {
                                                    show_err_msg("学生联系电话没有填");
                                                    return false;
                                                }
                                            } else {
                                                show_err_msg("学生民族没有选择");
                                                return false;
                                            }
                                        } else {
                                            show_err_msg("学生性别没有选择");
                                            return false;
                                        }
                                    } else {
                                        show_err_msg("学生照片没有上传");
                                        return false;
                                    }
                                } else {
                                    show_err_msg("学生姓名没有填");
                                    return false;
                                }
                            } else {
                                show_err_msg("密码没有填");
                                return false;
                            }
                        } else {
                            show_err_msg("学号没有填");
                            return false;
                        }
                    }
                    document.getElementById("studentInfoInsert_Add").addEventListener("click", function() {
                    if (jiaoyan()) {
                        $.post("../Handler/studentInfoInsert_Add.aspx", {
                            "StudentId": document.getElementById("studentInfoInsert_StudentId").value.trim(),
                            "StudentPassword": document.getElementById("studentInfoInsert_StudentPassword").value.trim(),
                            "StudentName": document.getElementById("studentInfoInsert_StudentName").value.trim(),
                            "StudentPhoto": document.getElementById("studentInfoInsert_StudentPhoto").getAttribute("data-src"),
                            "StudentSex": document.getElementById("studentInfoInsert_StudentSex").value.trim(),
                            "StudentNation": document.getElementById("studentInfoInsert_StudentNation").value.trim(),
                            "StudentTelehpone": document.getElementById("studentInfoInsert_StudentTelehpone").value.trim(),
                            "StudentQQ": document.getElementById("studentInfoInsert_StudentQQ").value.trim(),
                            "StudentClass": document.getElementById("studentInfoInsert_StudentClass").value.trim(),
                            "StudentDormitory": document.getElementById("studentInfoInsert_StudentDormitory").value.trim(),
                            "StudentAddress": function() { var StudentAddress = ""; var loc_province = document.getElementById("loc_province"); var loc_city = document.getElementById("loc_city"); var loc_town = document.getElementById("loc_town"); StudentAddress = StudentAddress + getSelectedText(loc_province) + "-" + getSelectedText(loc_city) + "-" + getSelectedText(loc_town); return StudentAddress; } //document.getElementById("studentInfoInsert_StudentAddress").value.trim()
                        }, function(data) {
                            if (data == "ok") {
                                alert("添加成功");
                                studentInfoInsert_Control_Init();
                            } else {
                                if (data == "no") {
                                    alert("出现未知问题，请联系管理员");
                                } else {
                                    alert(data);
                                }
                            }
                        })
                    }
                })
            }
            if (document.getElementById("studentInfoInsert_Cancel")) {
                document.getElementById("studentInfoInsert_Cancel").addEventListener("click", studentInfoInsert_Control_Init);
            }
        });
        //点击学生信息查询
        document.getElementById("studentInfoSelectList_Control").addEventListener("click", function() {
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">学生管理</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">学生信息查询</a></li></ul>";
            mainChildrenHide();
            var nowPage = 1;
            studentInfoSelectList_Get = function() {
                $.get("../Handler/studentInfoSelectList.aspx", {
                    "wherestr": function() {
                        if (document.getElementById("studentInfoSelectList_Value").value.trim() != "") {
                            return document.getElementById("studentInfoSelectList_Key").value + "=" + document.getElementById("studentInfoSelectList_Value").value.trim();
                        } else {
                            return "";
                        }
                    },
                    "nowPage": nowPage
                }, function(data) {
                    var tbodyData = "";
                    var JsonData = JSON.parse(data);
                    if (Math.ceil(JsonData.RecordCount / 10) != 0) {
                        document.getElementById("studentInfoSelectList").getElementsByClassName("nowPage")[0].innerHTML = nowPage;
                        document.getElementById("studentInfoSelectList").getElementsByClassName("sumPage")[0].innerHTML = Math.ceil(JsonData.RecordCount / 10);
                        for (var i = 0; i < JsonData.product.length; i++) {
                            tbodyData = tbodyData + "<tr onmouseover=\"this.style.backgroundColor='#ffff66';\" onmouseout=\"this.style.backgroundColor='#d4e3e5';\">";
                            tbodyData = tbodyData + "<td>" + JsonData.product[i].StudentId + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData.product[i].StudentPassword + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData.product[i].StudentName + "</td>";
                            tbodyData = tbodyData + "<td><img src='" + JsonData.product[i].StudentPhoto + "'data-src=" + JsonData.product[i].StudentPhoto + " style='height:100px;width:75px'/></td>";
                            tbodyData = tbodyData + "<td>" + JsonData.product[i].StudentSex + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData.product[i].StudentNation + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData.product[i].StudentTelehpone + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData.product[i].StudentQQ + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData.product[i].StudentClass + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData.product[i].StudentDormitory + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData.product[i].StudentAddress + "</td>";
                            tbodyData = tbodyData + '<td><a href="javascript:void(0)" class="StudentInfoSelect_Delete">删除</a></td>';
                            tbodyData = tbodyData + "</tr>";
                        }
                        document.getElementById("studentInfoSelectList").getElementsByTagName("tfoot")[0].getElementsByTagName("td")[0].setAttribute("colspan", 12);
                    } else {
                        tbodyData = tbodyData + "没有数据";
                        document.getElementById("studentInfoSelectList").getElementsByClassName("nowPage")[0].innerHTML = 0;
                        document.getElementById("studentInfoSelectList").getElementsByClassName("sumPage")[0].innerHTML = 0;
                    }
                    document.getElementById("studentInfoSelectList").getElementsByTagName("tbody")[0].innerHTML = tbodyData;
                    if (document.getElementsByClassName("StudentInfoSelect_Delete").length > 0) {
                        for (var i = 0; i < document.getElementsByClassName("StudentInfoSelect_Delete").length; i++) {
                            document.getElementsByClassName("StudentInfoSelect_Delete")[i].addEventListener("click", function(e) {
                                $.get("../Handler/StudentInfoSelect_Delete.aspx", {
                                    "StudentId": e.target.parentNode.parentNode.firstChild.innerHTML,
                                    "Img":e.target.parentNode.parentNode.getElementsByTagName("img")[0].getAttribute("data-src")
                                }, function(data) {
                                    if (data == "ok") {
                                        studentInfoSelectList_Get();
                                    }
                                })
                            })
                        }
                    }
                    if (document.getElementById("studentInfoSelectList").getElementsByClassName("UpPage").length > 0) {
                        for (var i = 0; i < document.getElementById("studentInfoSelectList").getElementsByClassName("UpPage").length; i++) {
                            document.getElementById("studentInfoSelectList").getElementsByClassName("UpPage")[i].addEventListener("click", UpPage)
                        }
                    }
                    if (document.getElementById("studentInfoSelectList").getElementsByClassName("DownPage").length > 0) {
                        for (var i = 0; i < document.getElementById("studentInfoSelectList").getElementsByClassName("DownPage").length; i++) {
                            document.getElementById("studentInfoSelectList").getElementsByClassName("DownPage")[i].addEventListener("click", DownPage)
                        }
                    }
                })
            }
            var UpPage = function() {
                if (parseInt(document.getElementById("studentInfoSelectList").getElementsByClassName("nowPage")[0].innerHTML) > 1) {
                    nowPage = nowPage - 1;
                    studentInfoSelectList_Get();
                }
            }
            var DownPage = function() {
                if (parseInt(document.getElementById("studentInfoSelectList").getElementsByClassName("nowPage")[0].innerHTML) < parseInt(document.getElementById("studentInfoSelectList").getElementsByClassName("sumPage")[0].innerHTML)) {
                    nowPage = nowPage + 1;
                    studentInfoSelectList_Get();
                }
            }
            studentInfoSelectList_Get();
            document.getElementById("studentInfoSelectList").style.display = "block";
            document.getElementById("studentInfoSelectList_query").addEventListener("click", function() {
                studentInfoSelectList_Get();
            })

        });
        //        //点击学生信息查看
        document.getElementById("studentInfoSelect_Control").addEventListener("click", function() {
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">学生管理</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">学生信息查看</a></li></ul>";
            mainChildrenHide();
            StudentQuery();
            document.getElementById("studentInfoSelect").style.display = "block";

        });
        //点击课程信息添加
        document.getElementById("CourseInfoAdd_Control").addEventListener("click", function() {
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">课程管理</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">课程信息添加</a></li></ul>";
            mainChildrenHide();
            document.getElementById("CourseInfoAdd").style.display = "block";
            CourseInfoAdd_Init = function() {
                document.getElementById("CourseInfoAdd_CouresId").value = "";
                document.getElementById("CourseInfoAdd_CourseName").value = "";
                document.getElementById("CourseInfoAdd_CourseTeacher").value = "";
                document.getElementById("CourseInfoAdd_CourseInfo").value = "";
                document.getElementById("CourseInfoAdd_CourseStudentNum").value = "";
            };
            document.getElementById("CourseInfoAdd_Submit").addEventListener("click", function() {
                if (document.getElementById("CourseInfoAdd_CouresId").value.trim() != "") {
                    if (!isNaN(document.getElementById("CourseInfoAdd_CouresId").value.trim())) {
                        if (document.getElementById("CourseInfoAdd_CourseName").value.trim() != "") {
                            if (document.getElementById("CourseInfoAdd_CourseTeacher").value.trim() != "") {
                                if (document.getElementById("CourseInfoAdd_CourseInfo").value.trim() != "") {
                                    if (document.getElementById("CourseInfoAdd_CourseStudentNum").value.trim() != "") {
                                        if (!isNaN(document.getElementById("CourseInfoAdd_CourseStudentNum").value.trim())) {
                                            $.post("../Handler/CourseInfoAdd.aspx", {
                                                "CouresId": document.getElementById("CourseInfoAdd_CouresId").value.trim(),
                                                "CourseName": document.getElementById("CourseInfoAdd_CourseName").value.trim(),
                                                "CourseTeacher": document.getElementById("CourseInfoAdd_CourseTeacher").value.trim(),
                                                "CourseInfo": document.getElementById("CourseInfoAdd_CourseInfo").value.trim(),
                                                "CourseStudentSumNum": document.getElementById("CourseInfoAdd_CourseStudentNum").value.trim()
                                            }, function(data) {
                                                if (data == "ok") {
                                                    show_msg("课程添加成功");
                                                    CourseInfoAdd_Init();
                                                } else {
                                                    if (data == "CourseId") {
                                                        show_err_msg("该课程编号存在，请更换");
                                                        document.getElementById("CourseInfoAdd_CouresId").value = "";
                                                        document.getElementById("CourseInfoAdd_CouresId").focus();
                                                    } else {
                                                        show_err_msg("出现未知错误，请联系管理员");
                                                    }
                                                }
                                            })
                                        } else {
                                            show_err_msg("允许选课人数，请输入数字");
                                            document.getElementById("CourseInfoAdd_CourseStudentNum").focus();
                                        }
                                    } else {
                                        show_err_msg("允许选课人数，没有填");
                                        document.getElementById("CourseInfoAdd_CourseStudentNum").focus();
                                    }
                                } else {
                                    show_err_msg("课程介绍，没有填");
                                    document.getElementById("CourseInfoAdd_CourseInfo").focus();
                                }
                            } else {
                                show_err_msg("授课教师，没有填");
                                document.getElementById("CourseInfoAdd_CourseTeacher").focus();
                            }
                        } else {
                            show_err_msg("课程名称，没有填");
                            document.getElementById("CourseInfoAdd_CourseName").focus();
                        }
                    } else {
                        show_err_msg("课程编号，请输入数字");
                        document.getElementById("CourseInfoAdd_CouresId").focus();
                    }
                } else {
                    show_err_msg("课程编号，没有填");
                    document.getElementById("CourseInfoAdd_CouresId").focus();
                }
            });
            document.getElementById("CourseInfoAdd_Cancel").addEventListener("click", CourseInfoAdd_Init);
        });

        //点击课程信息管理
        document.getElementById("CourseInfoManager_Control").addEventListener("click", function() {
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">课程管理</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">课程信息管理</a></li></ul>";
            //从数据库当中请求到所有的课程信息，并填充
            var nowPage = 1;
            var CourseInfoManager = function() {
                $.get("../Handler/CourseInfoManager.aspx", {
                    "nowPage": nowPage
                }, function(data) {

                    var JsonData = JSON.parse(data);
                    var tbodyData
                    var sumPage = Math.ceil(JsonData.RecordCount / 10);
                    if (sumPage != 0) {
                        document.getElementById("CourseInfoManager").getElementsByClassName("nowPage")[0].innerHTML = nowPage;
                        document.getElementById("CourseInfoManager").getElementsByClassName("sumPage")[0].innerHTML = sumPage;
                        tbodyData = "";
                        for (var i = 0; i < JsonData["product"].length; i++) {
                            tbodyData = tbodyData + "<tr onmouseover=\"this.style.backgroundColor='#ffff66';\" onmouseout=\"this.style.backgroundColor='#d4e3e5';\">";
                            tbodyData = tbodyData + "<td>" + JsonData["product"][i].CourseId + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData["product"][i].CourseName + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData["product"][i].CourseTeacher + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData["product"][i].CourseInfo + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData["product"][i].CourseStudentSumNum + "</td>";
                            tbodyData = tbodyData + "<td>" + JsonData["product"][i].CourseStudentNum + "</td>";
                            tbodyData = tbodyData + '<td><a href="javascript:void(0)" class="CourseInfoManager_Select">详情</a></td><td><a href="javascript:void(0)" class="CourseInfoManager_Delete">删除</a></td>';
                            tbodyData = tbodyData + "</tr>";
                        }
                        document.getElementById("CourseInfoManager").getElementsByTagName("tfoot")[0].getElementsByTagName("td")[0].setAttribute("colspan", 8)
                    } else {
                        tbodyData = "没有数据";
                        document.getElementById("CourseInfoManager").getElementsByClassName("nowPage")[0].innerHTML = 0;
                        document.getElementById("CourseInfoManager").getElementsByClassName("sumPage")[0].innerHTML = 0;
                    }

                    document.getElementById("CourseInfoManager").getElementsByTagName("tbody")[0].innerHTML = tbodyData;
                    if (document.getElementById("CourseInfoManager").getElementsByClassName("UpPage").length > 0) {
                        for (var i = 0; i < document.getElementById("CourseInfoManager").getElementsByClassName("UpPage").length; i++) {
                            document.getElementById("CourseInfoManager").getElementsByClassName("UpPage")[i].addEventListener("click", UpPage)
                        }
                    }
                    if (document.getElementById("CourseInfoManager").getElementsByClassName("DownPage").length > 0) {
                        for (var i = 0; i < document.getElementById("CourseInfoManager").getElementsByClassName("DownPage").length; i++) {
                            document.getElementById("CourseInfoManager").getElementsByClassName("DownPage")[i].addEventListener("click", DownPage)
                        }
                    }
                    mainChildrenHide();
                    document.getElementById("CourseInfoManager").style.display = "block";
                    //判断课程信息管理列表中，操作中的详情是否存在
                    if (document.getElementsByClassName("CourseInfoManager_Select")) {
                        for (var i = 0; i < document.getElementsByClassName("CourseInfoManager_Select").length; i++) {
                            document.getElementsByClassName("CourseInfoManager_Select")[i].addEventListener("click", function(e) {
                                //存储原来的成绩
                                var data;
                                //存放新的成绩
                                var newdata;
                                //根据点击的不同详情，获取信息填充到 详情里面
                                $.get("../Handler/CouresInfoSelect.aspx", {
                                    "CourseId": e.target.parentNode.parentNode.firstChild.innerHTML
                                }, function(data) {
                                    if (data != "no") {
                                        var dataTbody = "";
                                        var JsonData = JSON.parse(data);
                                        document.getElementById("CouresInfoSelect_CourseId").innerHTML = JsonData.CourseId;
                                        document.getElementById("CouresInfoSelect_CourseName").innerHTML = JsonData.CourseName;
                                        document.getElementById("CouresInfoSelect_CourseTeacher").innerHTML = JsonData.CourseTeacher;
                                        document.getElementById("CouresInfoSelect_CourseInfo").innerHTML = JsonData.CourseInfo;
                                        document.getElementById("CouresInfoSelect_CourseStudentNum").innerHTML = JsonData.CourseStudentNum;
                                        var nowPage = 1;
                                        var View_Course = function() {
                                            $.get("../Handler/View_Course.aspx", {
                                                "CourseId": JsonData.CourseId,
                                                "nowpage": nowPage
                                            }, function(data_) {
                                                dataTbody = "";
                                                var Jsondata_ = JSON.parse(data_);
                                                var sumpage = Math.ceil(Jsondata_.RecordCount / 10);
                                                if (sumpage != 0) {
                                                    document.getElementById("CouresInfoSelect").getElementsByClassName("nowPage")[0].innerHTML = nowPage;
                                                    document.getElementById("CouresInfoSelect").getElementsByClassName("sumPage")[0].innerHTML = sumpage;
                                                    for (var i = 0; i < Jsondata_.product.length; i++) {
                                                        dataTbody = dataTbody + "<tr onmouseover=\"this.style.backgroundColor='#ffff66';\" onmouseout=\"this.style.backgroundColor='#d4e3e5';\">";

                                                        dataTbody = dataTbody + "<td>";
                                                        dataTbody = dataTbody + Jsondata_.product[i].StudentId;
                                                        dataTbody = dataTbody + "</td>";

                                                        dataTbody = dataTbody + "<td>";
                                                        dataTbody = dataTbody + Jsondata_.product[i].StudentName;
                                                        dataTbody = dataTbody + "</td>";

                                                        dataTbody = dataTbody + "<td>";
                                                        dataTbody = dataTbody + Jsondata_.product[i].StudentClass;
                                                        dataTbody = dataTbody + "</td>";

                                                        dataTbody = dataTbody + "<td>";
                                                        dataTbody = dataTbody + Jsondata_.product[i].CourseName;
                                                        dataTbody = dataTbody + "</td>";

                                                        dataTbody = dataTbody + "<td>";
                                                        dataTbody = dataTbody + Jsondata_.product[i].CourseScore;
                                                        dataTbody = dataTbody + "</td>";

                                                        dataTbody = dataTbody + '<td><a href="javascript:void(0)" class="CouresInfoSelect_Edit">编辑</a></td><td style="display:none"><a href="javascript:void(0)" class="CouresInfoSelect_Cancel" >取消</a></td><td><a href="javascript:void(0)" class="CouresInfoSelect_Submit">确定</a></td><td><a href="javascript:void(0)" class="CouresInfoSelect_Delete">删除</a></td>';

                                                        dataTbody = dataTbody + "<td style=\"display:none\">" + Jsondata_.product[i].CourseId + "</td>";
                                                        dataTbody = dataTbody + "<td style=\"display:none\">" + Jsondata_.product[i].Id + "</td>";

                                                        dataTbody = dataTbody + "</tr>";
                                                    }
                                                    document.getElementById("CouresInfoSelect").getElementsByTagName("tfoot")[0].getElementsByTagName("td")[0].setAttribute("colspan", 8)
                                                } else {
                                                    dataTbody = dataTbody + "没有数据";
                                                    document.getElementById("CouresInfoSelect").getElementsByClassName("nowPage")[0].innerHTML = 0;
                                                    document.getElementById("CouresInfoSelect").getElementsByClassName("sumPage")[0].innerHTML = 0;
                                                }
                                                document.getElementById("CouresInfoSelect").getElementsByTagName("tbody")[0].innerHTML = dataTbody;
                                                if (document.getElementsByClassName("CouresInfoSelect_Edit")) {
                                                    for (var j = 0; j < document.getElementsByClassName("CouresInfoSelect_Edit").length; j++) {
                                                        document.getElementsByClassName("CouresInfoSelect_Edit")[j].addEventListener("click", function(e) {
                                                            if (e.target.parentNode.previousElementSibling.getElementsByTagName("input").length != 0) {
                                                                newdata = e.target.parentNode.previousElementSibling.getElementsByTagName("input")[0].value;
                                                            } else {
                                                                data = e.target.parentNode.previousElementSibling.innerText;
                                                            }
                                                            e.target.parentNode.previousElementSibling.innerHTML = "<input type=\"Text\" value=" + data + "></input>";
                                                            e.target.parentNode.parentNode.getElementsByClassName("CouresInfoSelect_Edit")[0].parentNode.style.display = "none";
                                                            e.target.parentNode.parentNode.getElementsByClassName("CouresInfoSelect_Cancel")[0].parentNode.style.display = "block";
                                                        })
                                                    }
                                                }
                                                //判断取消按钮是否存在
                                                if (document.getElementsByClassName("CouresInfoSelect_Cancel")) {
                                                    //为所有的取消按钮绑定事件
                                                    for (var j = 0; j < document.getElementsByClassName("CouresInfoSelect_Cancel").length; j++) {
                                                        document.getElementsByClassName("CouresInfoSelect_Cancel")[j].addEventListener("click", function(e) {
                                                            e.target.parentNode.previousElementSibling.previousElementSibling.innerHTML = data;
                                                            e.target.parentNode.parentNode.getElementsByClassName("CouresInfoSelect_Edit")[0].parentNode.style.display = "block";
                                                            e.target.parentNode.parentNode.getElementsByClassName("CouresInfoSelect_Cancel")[0].parentNode.style.display = "none";
                                                        })
                                                    }
                                                }
                                                //判断确定按钮是否存在
                                                if (document.getElementsByClassName("CouresInfoSelect_Submit")) {
                                                    //为所有的确定按钮绑定事件
                                                    for (var j = 0; j < document.getElementsByClassName("CouresInfoSelect_Submit").length; j++) {
                                                        document.getElementsByClassName("CouresInfoSelect_Submit")[j].addEventListener("click", function(e) {
                                                            //使用ajax将数据发送到后台，根据学号和课程名称，获取数据并更新
                                                            if (e.target.parentNode.parentNode.getElementsByTagName("input").length > 0) {
                                                                $.post("../Handler/CouresInfoSelect_Update.aspx", {
                                                                    "Id": e.target.parentNode.parentNode.lastChild.innerHTML,
                                                                    "StudentId": e.target.parentNode.parentNode.firstChild.innerHTML,
                                                                    "CourseId": e.target.parentNode.parentNode.lastChild.previousElementSibling.innerHTML,
                                                                    "CourseScore": e.target.parentNode.parentNode.getElementsByTagName("input")[0].value
                                                                }, function(data) {
                                                                    if (data == "ok") {
                                                                        e.target.parentNode.previousElementSibling.previousElementSibling.previousElementSibling.innerHTML = e.target.parentNode.parentNode.getElementsByTagName("input")[0].value;
                                                                        e.target.parentNode.parentNode.getElementsByClassName("CouresInfoSelect_Edit")[0].parentNode.style.display = "block";
                                                                        e.target.parentNode.parentNode.getElementsByClassName("CouresInfoSelect_Cancel")[0].parentNode.style.display = "none";
                                                                    } else {
                                                                        show_err_msg("更新失败，出现错误,请重试无效后联系管理员");
                                                                    }
                                                                })
                                                            }
                                                        })
                                                    }
                                                }
                                                //判断删除按钮是否存在
                                                if (document.getElementsByClassName("CouresInfoSelect_Delete")) {
                                                    //为所有的删除按钮绑定事件
                                                    for (var j = 0; j < document.getElementsByClassName("CouresInfoSelect_Delete").length; j++) {
                                                        document.getElementsByClassName("CouresInfoSelect_Delete")[j].addEventListener("click", function(e) {
                                                            //使用ajax将数据发送到后台，后台根据发送过去的学号和课程名称 从成绩表中删除相应数据
                                                            $.post("../Handler/CouresInfoSelect_Delete.aspx", {
                                                                "Id": e.target.parentNode.parentNode.lastChild.innerHTML
                                                            }, function(data) {
                                                                if (data == "ok") {
                                                                    e.target.parentNode.parentNode.parentNode.removeChild(e.target.parentNode.parentNode);
                                                                } else {
                                                                    show_err_msg("删除失败，出现错误,请重试无效后联系管理员");
                                                                }
                                                            })
                                                        })
                                                    }
                                                }

                                            })
                                        }
                                        var UpPage = function() {
                                            if (parseInt(document.getElementById("CouresInfoSelect").getElementsByClassName("nowpage")[0].innerHTML) > 1) {
                                                nowPage = nowPage - 1;
                                                View_Course();
                                            }
                                        }
                                        var DownPage = function() {
                                            if (parseInt(document.getElementById("CouresInfoSelect").getElementsByClassName("nowpage")[0].innerHTML) < parseInt(document.getElementById("CourseInfoManager").getElementsByClassName("sumpage")[0].innerHTML)) {
                                                nowPage = nowPage + 1;
                                                View_Course();
                                            }
                                        }
                                        View_Course();
                                    } else {
                                        show_err_msg("出现未知错误，请联系管理员");
                                    }

                                })
                                //获取详情
                                //填充详情
                                //显示
                                mainChildrenHide();
                                document.getElementById("CouresInfoSelect").style.display = "block";
                                //判断课程信息详情页，中的编辑是否存在

                            })
                        }
                    }
                    //判断课程信息管理列表中，操作中的删除是否存在
                    if (document.getElementsByClassName("CourseInfoManager_Delete")) {
                        for (var i = 0; i < document.getElementsByClassName("CourseInfoManager_Delete").length; i++) {
                            document.getElementsByClassName("CourseInfoManager_Delete")[i].addEventListener("click", function(e) {
                                //使用ajax将数据发送到后台，后台进行删除处理
                                $.get("../Handler/CourseInfoManager_Delete.aspx", {
                                    "CourseId": e.target.parentNode.parentNode.firstChild.innerHTML
                                }, function(data) {
                                    if (data == "ok") {
                                        e.target.parentNode.parentNode.parentNode.removeChild(e.target.parentNode.parentNode);
                                        CourseInfoManager();
                                    } else {
                                        alert("删除失败");
                                    }
                                })
                            })
                        }
                    }
                })
            }
            var UpPage = function() {
                if (parseInt(document.getElementById("CourseInfoManager").getElementsByClassName("nowpage")[0].innerHTML) > 1) {
                    nowPage = nowPage - 1;
                    CourseInfoManager();
                }
            }
            var DownPage = function() {
                if (parseInt(document.getElementById("CourseInfoManager").getElementsByClassName("nowpage")[0].innerHTML) < parseInt(document.getElementById("CourseInfoManager").getElementsByClassName("sumpage")[0].innerHTML)) {
                    nowPage = nowPage + 1;
                    CourseInfoManager();
                }
            }
            CourseInfoManager();
        });
        //点击课程成绩录入
        //        document.getElementById("CourseInfoInsert_Control").addEventListener("click", function() {
        //            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">课程管理</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">课程成绩录入</a></li></ul>";
        //            mainChildrenHide();
        //            document.getElementById("CourseInfoInsert").style.display = "block";
        //        });
        //点击学生选择课程
        document.getElementById("StudentCourseChoice_Control").addEventListener("click", function() {
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">课程管理</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">学生选择课程</a></li></ul>";
            mainChildrenHide();
            var courseSelectList = function() {
                $.get("../Handler/courseSelectList.aspx", {},
					function(data) {
					    var tbodyData = "";
					    var JsonData = JSON.parse(data);
					    $.get("../Handler/student_course_getStudentIdList.aspx", {
					        "StudentId": UserName
					    }, function(data) {
					        var JsonData_ = JSON.parse(data);
					        for (var i = 0; i < JsonData.length; i++) {
					            if (JsonData[i].CourseStudentSumNum > JsonData[i].CourseStudentNum) {

					                tbodyData = tbodyData + "<tr onmouseover=\"this.style.backgroundColor='#ffff66';\" onmouseout=\"this.style.backgroundColor='#d4e3e5';\">";
					                tbodyData = tbodyData + "<td>" + JsonData[i].CourseId + "</td>";
					                tbodyData = tbodyData + "<td>" + JsonData[i].CourseName + "</td>";
					                tbodyData = tbodyData + "<td>" + JsonData[i].CourseTeacher + "</td>";
					                tbodyData = tbodyData + "<td>" + JsonData[i].CourseInfo + "</td>";
					                tbodyData = tbodyData + "<td>" + JsonData[i].CourseStudentSumNum + "</td>";
					                tbodyData = tbodyData + "<td>" + JsonData[i].CourseStudentNum + "</td>";
					                var dd = ""
					                for (var j = 0; j < JsonData_.length; j++) {
					                    if (JsonData[i].CourseId == JsonData_[j].CourseId) {
					                        dd = "<td><input type=\"button\" disabled=\"disabled\" class=\"StudentCourseChoice_select\" value=\"已报名\" />";
					                    }
					                }
					                if (dd == "") {
					                    dd = "<td><input type=\"button\" class=\"StudentCourseChoice_select\" value=\"报名\" />";
					                }
					                tbodyData = tbodyData + dd;

					                tbodyData = tbodyData + "</tr>";
					            }
					            document.getElementById("StudentCourseChoice").getElementsByTagName("tbody")[0].innerHTML = tbodyData;
					            if (document.getElementsByClassName("StudentCourseChoice_select").length > 0) {
					                for (var i = 0; i < document.getElementsByClassName("StudentCourseChoice_select").length; i++) {
					                    document.getElementsByClassName("StudentCourseChoice_select")[i].addEventListener("click", function(e) {
					                        $.get("../Handler/course_Update.aspx", {
					                            "CourseId": e.target.parentNode.parentNode.firstChild.innerHTML,
					                            "StudentId": UserName
					                        }, function(data) {
					                            if (data == "ok") {
					                                e.target.value = "已报名";
					                                e.target.setAttribute("disabled", "disabled");
					                                e.target.parentNode.previousElementSibling.innerHTML = parseInt(e.target.parentNode.previousElementSibling.innerHTML) + 1;
					                            } else {
					                                show_err_msg("出现未知错误，请联系管理员");
					                            }
					                        })
					                    })
					                }
					            }
					        }
					    })
					})
            }
            courseSelectList();
            document.getElementById("StudentCourseChoice").style.display = "block";
        });
        //点击学生成绩查询
        document.getElementById("StudentCourseResultQuery_Control").addEventListener("click", function() {
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">课程管理</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">学生成绩查询</a></li></ul>";
            mainChildrenHide();
            var nowPage = 1;
            var View_Course_GetStudentIdList = function() {
                $.get("../Handler/View_Course_GetStudentIdList.aspx", {
                    "StudentId": UserName,
                    "nowPage": nowPage
                }, function(data) {
                    dataTbody = "";
                    var Jsondata_ = JSON.parse(data);
                    if (Jsondata_.RecordCount != 0) {
                        document.getElementById("StudentCourseResultQuery").getElementsByClassName("nowPage")[0].innerHTML = nowPage;
                        document.getElementById("StudentCourseResultQuery").getElementsByClassName("sumPage")[0].innerHTML = Math.ceil(Jsondata_.RecordCount / 10);
                        for (var i = 0; i < Jsondata_.product.length; i++) {
                            dataTbody = dataTbody + "<tr onmouseover=\"this.style.backgroundColor='#ffff66';\" onmouseout=\"this.style.backgroundColor='#d4e3e5';\">";

                            dataTbody = dataTbody + "<td>";
                            dataTbody = dataTbody + Jsondata_.product[i].StudentId;
                            dataTbody = dataTbody + "</td>";

                            dataTbody = dataTbody + "<td>";
                            dataTbody = dataTbody + Jsondata_.product[i].StudentName;
                            dataTbody = dataTbody + "</td>";

                            dataTbody = dataTbody + "<td>";
                            dataTbody = dataTbody + Jsondata_.product[i].StudentClass;
                            dataTbody = dataTbody + "</td>";

                            dataTbody = dataTbody + "<td>";
                            dataTbody = dataTbody + Jsondata_.product[i].CourseName;
                            dataTbody = dataTbody + "</td>";

                            dataTbody = dataTbody + "<td>";
                            if (parseFloat(Jsondata_.product[i].CourseScore) > 0) {
                                dataTbody = dataTbody + Jsondata_.product[i].CourseScore;
                            } else {
                                dataTbody = dataTbody + "尚未发布成绩";
                            }
                            dataTbody = dataTbody + "</td>";

                            dataTbody = dataTbody + "</tr>";
                        }
                    } else {
                        dataTbody = dataTbody + "没有数据";
                        document.getElementById("StudentCourseResultQuery").getElementsByClassName("nowPage")[0].innerHTML = 0;
                        document.getElementById("StudentCourseResultQuery").getElementsByClassName("sumPage")[0].innerHTML = 0;
                    }
                    document.getElementById("StudentCourseResultQuery").getElementsByTagName("tbody")[0].innerHTML = dataTbody;
                    if (document.getElementById("StudentCourseResultQuery").getElementsByClassName("UpPage").length > 0) {
                        for (var i = 0; i < document.getElementById("StudentCourseResultQuery").getElementsByClassName("UpPage").length; i++) {
                            document.getElementById("StudentCourseResultQuery").getElementsByClassName("UpPage")[i].addEventListener("click", UpPage)
                        }
                    }
                    if (document.getElementById("StudentCourseResultQuery").getElementsByClassName("DownPage").length > 0) {
                        for (var i = 0; i < document.getElementById("StudentCourseResultQuery").getElementsByClassName("DownPage").length; i++) {
                            document.getElementById("StudentCourseResultQuery").getElementsByClassName("DownPage")[i].addEventListener("click", DownPage)
                        }
                    }
                })
            }
            var UpPage = function() {
                if (parseInt(document.getElementById("StudentCourseResultQuery").getElementsByClassName("nowPage")[0].innerHTML) > 1) {
                    nowPage = nowPage - 1;
                    View_Course_GetStudentIdList();
                }
            }
            var DownPage = function() {
                if (parseInt(document.getElementById("StudentCourseResultQuery").getElementsByClassName("nowPage")[0].innerHTML) < parseInt(document.getElementById("StudentCourseResultQuery").getElementsByClassName("sumPage")[0].innerHTML)) {
                    nowPage = nowPage + 1;
                    View_Course_GetStudentIdList();
                }
            }
            View_Course_GetStudentIdList();
            document.getElementById("StudentCourseResultQuery").style.display = "block";
        });
        //点击新闻通知发布
        $(function() {
            var options = {
                success: function(data) {
                    // $("#responseText").text(data);
                    document.getElementById("NewsRelease_RelateFile").innerHTML = data;
                }
            };

            $("#form2").ajaxForm(options);
        });
        document.getElementById("NewsRelease_Control").addEventListener("click", function() {
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">通知管理</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">新闻通知发布</a></li></ul>";
            mainChildrenHide();
            var NewsRelease_Init = function() {
                document.getElementById("NewsRelease_Title").value = "";
                document.getElementById("NewsRelease_Author").value = "";
                document.getElementById("NewsRelease_ReleaseTime").value = getNowFormatDate();
                document.getElementById("NewsRelease_Content").value = "";
                document.getElementById("NewsRelease_RelateFile").innerHTML = "";
            }
            if (document.getElementById("NewsRelease_Submit")) {
                document.getElementById("NewsRelease_Submit").addEventListener("click", function() {
                    //完整性校验
                    if (document.getElementById("NewsRelease_Title").value.trim() != "") {
                        if (document.getElementById("NewsRelease_Author").value.trim() != "") {
                            if (document.getElementById("NewsRelease_ReleaseTime").value.trim() != "") {
                                if (document.getElementById("NewsRelease_Content").value.trim() != "") {
                                    $.post(
										"../Handler/NewsRelease_Add.aspx", {
										    "Title": document.getElementById("NewsRelease_Title").value.trim(),
										    "Author": document.getElementById("NewsRelease_Author").value.trim(),
										    "ReleaseTime": document.getElementById("NewsRelease_ReleaseTime").value.trim(),
										    "Content": document.getElementById("NewsRelease_Content").value.trim(),
										    "RelateFile": document.getElementById("NewsRelease_RelateFile").innerHTML
										},
										function(data) {
										    if (data == "ok") {
										        show_msg("新闻发布成功");
										        NewsRelease_Init();
										    }
										})
                                } else {
                                    show_err_msg("新闻内容为空");
                                    document.getElementById("NewsRelease_Content").focus();
                                }
                            } else {
                                show_err_msg("新闻发布时间为空");
                                document.getElementById("NewsRelease_ReleaseTime").focus();
                            }
                        } else {
                            show_err_msg("新闻作者为空");
                            document.getElementById("NewsRelease_Author").focus();
                        }
                    } else {
                        show_err_msg("新闻标题为空");
                        document.getElementById("NewsRelease_Title").focus();
                    }
                })
            }
            if (document.getElementById("NewsRelease_Cancel")) {
                document.getElementById("NewsRelease_Cancel").addEventListener("click", NewsRelease_Init);
            }
            document.getElementById("NewsRelease").style.display = "block";
        });
        //点击新闻列表
        document.getElementById("NewsList_Control").addEventListener("click", function() {
            document.getElementById("siteMap").innerHTML = "<ul><li><img src=\"../IMG/home.png\"></li><li style=\"margin-left: 25px;\">您当前的位置：</li><li><a href=\"javascript:void(0)\">通知管理</a></li><li>&gt;</li><li><a href=\"javascript:void(0)\">新闻列表</a></li></ul>";
            mainChildrenHide();
            var nowPage = 1;
            var NewsList_GetList = function() {
                $.get("../Handler/NewsList_GetList.aspx", {
                    "nowPage": nowPage
                }, function(data) {
                    dataTbody = "";
                    var Jsondata_ = JSON.parse(data);
                    if (Jsondata_.RecordCount != 0) {
                        document.getElementById("NewsList").getElementsByClassName("nowPage")[0].innerHTML = nowPage;
                        document.getElementById("NewsList").getElementsByClassName("sumPage")[0].innerHTML = Math.ceil(Jsondata_.RecordCount / 10);
                        for (var i = 0; i < Jsondata_.product.length; i++) {

                            dataTbody = dataTbody + "<tr onmouseover=\"this.style.backgroundColor='#ffff66';\" onmouseout=\"this.style.backgroundColor='#d4e3e5';\">";

                            dataTbody = dataTbody + "<td style='display:none'>";
                            dataTbody = dataTbody + Jsondata_.product[i].Id;
                            dataTbody = dataTbody + "</td>";

                            dataTbody = dataTbody + "<td>";
                            dataTbody = dataTbody + Jsondata_.product[i].Title;
                            dataTbody = dataTbody + "</td>";

                            dataTbody = dataTbody + "<td>";
                            dataTbody = dataTbody + Jsondata_.product[i].Author;
                            dataTbody = dataTbody + "</td>";

                            dataTbody = dataTbody + "<td>";
                            dataTbody = dataTbody + Jsondata_.product[i].ReleaseTime;
                            dataTbody = dataTbody + "</td>";

                            dataTbody = dataTbody + "<td>";
                            dataTbody = dataTbody + Jsondata_.product[i].Content;
                            dataTbody = dataTbody + "</td>";

                            dataTbody = dataTbody + "<td>";
                            if (Jsondata_.product[i].RelateFile.trim() != "") {
                                dataTbody = dataTbody + "<a href=\"" + Jsondata_.product[i].RelateFile + "\">附件</a>";
                            }

                            dataTbody = dataTbody + "</td>";
                            if (UserFlag == 1) {
                                dataTbody = dataTbody + "<td><input type='button' class='NewsList_Delete' value='删除'>"
                            }

                            dataTbody = dataTbody + "</tr>";
                        }
                    } else {
                        dataTbody = dataTbody + "没有数据";
                        document.getElementById("NewsList").getElementsByClassName("nowPage")[0].innerHTML = 0;
                        document.getElementById("NewsList").getElementsByClassName("sumPage")[0].innerHTML = 0;
                    }

                    document.getElementById("NewsList").getElementsByTagName("tbody")[0].innerHTML = dataTbody;
                    if (document.getElementById("NewsList").getElementsByClassName("NewsList_Delete").length > 0) {
                        for (var i = 0; i < document.getElementsByClassName("NewsList_Delete").length; i++) {
                            document.getElementsByClassName("NewsList_Delete")[i].addEventListener("click", function(e) {
                                NewsList_DeleteNew(e);
                            })
                        }
                    }
                    if (document.getElementById("NewsList").getElementsByClassName("UpPage").length > 0) {
                        for (var i = 0; i < document.getElementById("NewsList").getElementsByClassName("UpPage").length; i++) {
                            document.getElementById("NewsList").getElementsByClassName("UpPage")[i].addEventListener("click", UpPage)
                        }
                    }
                    if (document.getElementById("NewsList").getElementsByClassName("DownPage").length > 0) {
                        for (var i = 0; i < document.getElementById("NewsList").getElementsByClassName("DownPage").length; i++) {
                            document.getElementById("NewsList").getElementsByClassName("DownPage")[i].addEventListener("click", DownPage)
                        }
                    }
                })
            }
            var NewsList_DeleteNew = function(e) {
                var news_Id = e.target.parentNode.parentNode.firstChild.innerHTML;
                $.get("../Handler/NewsList_DeleteNew.aspx", {
                    "news_Id": news_Id
                }, function(data) {
                    if (data == "ok") {
                        NewsList_GetList();
                    }
                })
            }
            var UpPage = function() {
                if (parseInt(document.getElementById("NewsList").getElementsByClassName("nowPage")[0].innerHTML) > 1) {
                    nowPage = nowPage - 1;
                    NewsList_GetList();
                }
            }
            var DownPage = function() {
                if (parseInt(document.getElementById("NewsList").getElementsByClassName("nowPage")[0].innerHTML) < parseInt(document.getElementById("NewsList").getElementsByClassName("sumPage")[0].innerHTML)) {
                    nowPage = nowPage + 1;
                    NewsList_GetList();
                }
            }
            NewsList_GetList();

            document.getElementById("NewsList").style.display = "block";
        });

    } else {
        //跳转到错误页
        //alert("数据未找到");
        window.location.href = "../login.html";
    }

}
