var student = {} || student;
var classId = 0;
var semesterId = 0;
var subjectId = 0;

student.showStudent = function () {
    $.ajax({
        url: `/Student/GetStudentsByClassId/${classId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbStudent tbody').empty();
            $.each(data.students, function (i, v) {
                $('#tbStudent tbody').append(
                    `<tr>
                    <td>${v.studentId}</td>
                    <td>${v.firstName} ${v.lastName}</td>
                    <td>${v.gender}</td>
                    <td>${v.dayOfBirth}</td>
                    <td>${v.phoneNumber}</td>
                </tr>`
                );
            });
            studentData = data;
        }
    });
}
student.initSubject = function () {
    $.ajax({
        url: `/Subject/GetSubjectByClassId/${classId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbStudent thead').empty();
        
            $('#tbStudent thead').append(
                `
                     <th>Student Id</th>
                     <th>Student FullNAme</th>
                   
               `);
            $.each(data.subjects, function (i, v) {
                $('#tbStudent thead').append(
                    `
                    <th>${v.subjectName}</th>
                `
                );
            }); 
        }
    });
}
student.initSemester = function () {
    $.ajax({
        url: `/Subject/GetSubjectAll`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#SubjectId').empty();
            $('#SubjectId').append(`<option value=${0} >Subject select</option>`)
            $.each(data.subjects, function (i, v) {
                $('#SubjectId').append(`<option value=${v.subjectId} >${v.subjectName}</option>`)
            });
        }
    });
}
student.initSubject = function () {
    $.ajax({
        url: `/Semester/GetSemesterAll`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#SemesterId').empty();
            $('#SemesterId').append(`<option value=${0} >Semester select</option>`)
            $.each(data.semesterAlls, function (i, v) {
                $('#SemesterId').append(`<option value=${v.semesterId} >${v.semesterName}</option>`)
            });
        }
    });
}

student.init = function () {
    student.showStudent();
    student.initSubject();
    student.initSemester();

};
$(document).ready(function () {
    classId = $('#classId').val();
    student.init();
});