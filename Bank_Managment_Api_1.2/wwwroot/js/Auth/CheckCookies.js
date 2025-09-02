try
{
    var token = document.cookie
    .split(';')
    .find(row=>row.startsWith('access_token='))
    .split('=')[1];
    console.log(token)
}
catch(e)
{
    alert("You Don't Have Permision to Enter this Page")
    window.location.href = window.location.origin +"/Authentication/LogIn"

}
