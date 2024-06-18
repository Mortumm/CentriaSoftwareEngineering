const { serve } = Deno;

async function handleRequest(req: Request) {
  const url = new URL(req.url);

  if (req.method === 'PEEK' && url.pathname === '/secret') {
    return new Response('Peeking at secret data...');
  } else {
    return new Response('There is nothing to see here...');
  }
}

console.log("Server listening on port 8000");
serve(handleRequest, { port: 8000 });
