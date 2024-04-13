function loadComments(projectId) {
    $.ajax({

        url: '/ProjectManagement/ProjectComment/GetComments?projectId=' + projectId,
        method: 'GET',
        success: function (data) {
           console.log(data)
            var commentHtml = '';
            for (var i = 0; i<data.length; i++) {
                commentHtml += '<div class="comment"';
                commentHtml += '<p>comment: ' + data[i].content + '</p>'
                commentHtml += '<span style="color:gray;">Posted on ' + data[i].datePosted.toLocaleString() + '</span><hr>';
                commentHtml += '</div>'
            }
            $('#commentsList').html(commentHtml);
        }


    });
}
function loadTasks(projectId){
    $.ajax({

        url: '/ProjectManagement/ProjectTask/GetTasks?projectId=' + projectId,
        method: 'GET',
        success: function (data) {
            console.log(data)
            var TaskHtml = '';
            for (var i = 0; i < data.length; i++) {
                TaskHtml += '<div class="Task"';
                TaskHtml += '<p>task: ' + data[i].TaskName + '</p>'
                TaskHtml += '<p>task: ' + data[i].TaskDescription + '</p>'
                TaskHtml += '</div>'
            }
            $('#TaskList').html(TaskHtml);
        }


    });
}

$(document).ready(function () {

    var projectId = $('#projectComments input[name="ProjectId"]').val();

    loadComments(projectId);
    loadTasks(projectId)
    $('#addTaskForm').submit(function (e) {
        e.preventDefault();
        var formData = {
            ProjectId: projectId,
            TaskDescription: $('#projectTasks textarea[name = "Content"]').val()
        };
        $.ajax({

            url: '/ProjectManagement/Task/AddTasks',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                if (response.success) {
                    $('#projectTasks textarea[name = "Content"]').val('');
                    loadTasks(projectId);

                } else {
                    alert(response.message);

                }
            },
            error: function (error) {
                alert("Error " + error);
            }



        });




    });
    $('#addCommentForm').submit(function (e) {
        e.preventDefault();
        var formData = {
            ProjectId: projectId,
            Content: $('#projectComments textarea[name = "Content"]').val()
        };
        $.ajax({

            url: '/ProjectManagement/ProjectComment/AddComments',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                if (response.success) {
                    $('#projectComments textarea[name = "Content"]').val('');
                    loadComments(projectId);

                } else {
                    alert(response.message);

                }
            },
            error: function (error) {
                alert("Error " + error);
            }



        });




    });

})
