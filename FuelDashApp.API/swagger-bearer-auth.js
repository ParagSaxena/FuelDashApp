(function () {
    $(function () {
        $('#auth_container').append("<input type='text' id='input_apiKey' />");
        $("#input_apiKey").change(addApiKeyAuthorization);
    });

    function addApiKeyAuthorization() {
        var key = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InNkYXdzb25AbmV0ZmFjaWxpdGllcy5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL2V4cGlyYXRpb24iOiIxNTQ4ODcyNzczLjEwOTQyIiwibmJmIjoxNTE3MzE2OTczLCJleHAiOjE1MTk4MjI1NzMsImlhdCI6MTUxNzMxNjk3M30.OxAgRy3k3mXC798l6kgVYEt4OBZSAXsJ5WfopwsjYl4';
        if (key && key.trim() != "") {
            var apiKeyAuth = new SwaggerClient.ApiKeyAuthorization("Authorization", "Bearer " + key, "header");
            window.swaggerUi.api.clientAuthorizations.add("bearer", apiKeyAuth);
        }
    }
})();