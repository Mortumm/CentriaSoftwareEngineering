const waitAndPrint = async (message, seconds) => {
    await new Promise((resolve) => setTimeout(resolve, seconds * 1000));
    console.log(message);
  };
  
  const example = async () => {
  await waitAndPrint("First call!", 3);
  waitAndPrint("Second call!", 2);
  waitAndPrint("Third call!", 1);
  };
  
  example();