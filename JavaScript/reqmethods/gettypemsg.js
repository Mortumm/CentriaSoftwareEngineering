const handleRequest = (request) => {
  return new Response("You made a request with method " + request.method);
};

Deno.serve(handleRequest);
