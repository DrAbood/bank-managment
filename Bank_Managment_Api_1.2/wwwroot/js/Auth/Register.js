document.addEventListener('DOMContentLoaded', function() {
                    
    document.getElementById("registerForm").addEventListener('submit', function(event) 
    {   event.stopImmediatePropagation();
        event.preventDefault();

        newUser = {
            Name: $("#Name").val(),       // () required
            Email: $("#Email").val(),     // () required
            MobileNumber: $("#Number").val(), 
            DateOfBirth: new Date($("#Birth").val()).toISOString().split('T')[0],
            Role: $("#Role").val(),       // : not =
            Password: $("#password").val()
        }

        fetch('http://'+ window.location.host + '/Auth/Register',{
            method: 'POST',
            headers:{ 'Content-type' : 'application/json'},
            body: JSON.stringify(newUser)
        }).then(res =>
        {
            if (!res.ok){
                console.log('problem');
                return;
            }
            if (res.status >= 500)
            {
                window.location.href= window.location.origin + "/Errors"
            }
            if(res.ok)
            {
                console.log('sucess');
                window.location.href='Login';
            }

            return res.json();
        })
        // .then(data=> {

        // })
        .catch(error=> 
        {
            console.log(error)
        })
        



    }, true);
}, true);