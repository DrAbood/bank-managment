document.addEventListener('DOMContentLoaded', function() {
                    
                    document.getElementById("loginForm").addEventListener('submit', function(event) 
                    {
                        event.stopPropagation();
                        event.preventDefault();

                            const User = {
                                UserName: $("#Name").val(),       
                                Password: $("#password").val()
                            }

                            fetch('http://'+ window.location.host + '/Auth/login',{
                                method: 'POST',
                                headers:{ 'Content-type' : 'application/json'},
                                body: JSON.stringify(User)
                            }).then(res =>
                            {

                                if (res.status == 401)
                                {
                                    alert("Invalid password or Username")
                                    $("#password").val(""); 
                                    $("#password").focus(); 
                                    
                                }
                                if (res.status >= 500)
                                {
                                    window.location.href= window.location.origin + "/Errors"
                                }
                                else if (!res.ok){
                                    console.log('problem');
                                    console.log(res);
                                    throw new Error(`Server error: ${response.status} - ${error}`);
                                    
                                }
                                // else
                                // {            
                                //     console.log('sucess');
                                //     // console.log(res.json());
                                // }
                                
                                return res.json();
                            })
                            .then(data=> {
                                var now = new Date();
                                var time = now.getTime();
                                time += 3600 * 1000;
                                now.setTime(time);

                                console.log(data.token);
                                document.cookie=`access_token = ${data.token}; path=/;expires=${now.toUTCString()}`
                                window.location.href= window.location.origin + "/Account/Main"

                            })
                            .catch(error=> 
                            {
                                console.log(error)
                            })
                    });
                });