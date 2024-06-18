const handleRequest = (request) => {
  const url = new URL(request.url);

  let message = "one";
  if (url.pathname === "/one") {
    message = "yksi";
  } else if (url.pathname.includes("/two")) {
    message = "kaksi";
  } else if (url.pathname.includes("/")) {
    message = "pong";
  }

  return new Response(message);
};

Deno.serve(handleRequest);
