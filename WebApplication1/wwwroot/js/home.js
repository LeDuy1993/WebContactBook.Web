var home = {} || home;

var datas = {};
var courseId = 0;
var gradeId = 0;

home.initCourse = function () {
    $.ajax({
        url: `/Home/GetAllCourses`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#CourseId').empty();
            $('#CourseId').append(`<option value=${0} >Course select</option>`)
            $.each(data.courses, function (i, v) {
                $('#CourseId').append(`<option value=${v.courseId} >${v.courseName}</option>`)
            });
        }
    });
}
home.initGrade = function () {
    $.ajax({
        url: `/Home/GetAllGrades`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#GradeId').empty();
            $('#GradeId').append(`<option value=${0} >Grade select</option>`)
            $.each(data.grades, function (i, v) {
                $('#GradeId').append(`<option value=${v.gradeId} >${v.gradeName}</option>`)
            });
        }
    });
}

home.search = function () {
    courseId = $("#CourseId").val();
    gradeId = $("#GradeId").val();
    $.ajax({
        url: `/Home/GetsByCourseIdAndGradeId/${courseId}/${gradeId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbClass tbody').empty();
            $.each(data.classRooms, function (i, v) {
                $('#tbClass tbody').append(
                    `<tr>
                    <td>${v.classId}</td>
                    <td>${v.className}</td>
                    <td>${v.students}</td>
                    <td>${v.teacherName}</td>   
                    <td>
                        <a href="/Student/List/${v.classId}" class="btn btn-success">List Students</a>   
                    </td>
                </tr>`
                );
            });
        }
    });
}

home.init = function () {
    home.initCourse();
    home.initGrade();
    home.search();
};

$(document).ready(function () {
    home.init();
});