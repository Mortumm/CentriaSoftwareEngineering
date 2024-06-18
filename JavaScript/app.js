const handleRequest = (request) => {
    console.log(`Request method: ${request.method}`);
    console.log(`Request url: ${request.url}`);
    return new Response("This is a test!");
  };
  
  Deno.serve(handleRequest);