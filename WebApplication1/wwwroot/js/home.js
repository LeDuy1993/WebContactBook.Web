var home = {} || home;

home.initCourse = function () {
    $.ajax({
        url: `/Home/GetAllCourses`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#CourseSelect').empty();
            $.each(data.courses, function (i, v) {
                $('#CourseSelect').append(`<option value=${v.courseId} >${v.courseName}</option>`)
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
            $('#GradeSelect').empty();
            $.each(data.grades, function (i, v) {
                $('#GradeSelect').append(`<option value=${v.gradeId} >${v.gradeName}</option>`)
            });
        }
    });
}

home.init = function () {
    home.initCourse();
    home.initGrade();
};


$(document).ready(function () {
    home.init();
});