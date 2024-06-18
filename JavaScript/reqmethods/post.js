const handleRequest = (request) => {
  let message = "Unable to comply..."; // Default message, gives this when no match in if or else if functions.

  if (request.method === "GET") {
    message = "Retrieving data...";
  } else if (request.method === "POST") {
    message = "Posting data...";
  }

  return new Response(message);
};

Deno.serve(handleRequest);
