$(document).ready(function () {
    autosize(document.querySelectorAll('.autosize'));

    document.querySelectorAll('.form-control').forEach(function (textarea) {
        textarea.addEventListener('input', function () {
            autosize.update(this);
        });
    });

    document.getElementById('Resume').addEventListener('change', function () {
        document.getElementById('resumeError').innerText = '';
        updateFileName();
    });

    document.getElementById('Resume').form.addEventListener('submit', function (event) {
        var input = document.getElementById('Resume');
        if (!input.files || input.files.length === 0) {
            document.getElementById('resumeError').innerText = 'Resume is required.';
            event.preventDefault();
        } else {
            var fileName = input.files[0].name;
            if (!fileName.toLowerCase().endsWith('.pdf')) {
                document.getElementById('resumeError').innerText = 'The file should be in PDF format.';
                event.preventDefault();
            }
        }
    });

    function updateFileName() {
        var input = document.getElementById('Resume');
        var fileNameDisplay = document.getElementById('selectedFileName');

        if (input.files.length > 0) {
            var fileName = input.files[0].name;

            if (fileName.toLowerCase().endsWith('.pdf')) {
                fileNameDisplay.innerText = fileName;
                previewFile();
            } else {
                fileNameDisplay.innerText = '';
                document.getElementById('resumeError').innerText = 'The file should be in PDF format.';
            }
        } else {
            fileNameDisplay.innerText = '';
            document.getElementById('resumeError').innerText = '';
        }
    }

    function previewFile() {
        var input = document.getElementById('Resume');
        var filePreview = document.getElementById('filePreview');

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                if (input.files[0].name.toLowerCase().endsWith('.pdf')) {
                    var iframe = document.createElement('iframe');
                    iframe.src = e.target.result;
                    iframe.style.width = '100%';
                    iframe.style.height = '78.8vh';
                    filePreview.innerHTML = '';
                    filePreview.appendChild(iframe);
                } else {
                    filePreview.innerHTML = 'File preview is not available for this file type.';
                }
            };

            reader.readAsDataURL(input.files[0]);
        }
    }
});