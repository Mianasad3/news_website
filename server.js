const httpModule = require("http");
const fileSystemModule = require("fs");

const requestListener = (req, res) => {
    if (req.url === "/news")
    {
        const handleFileRead = (err, contents) => {
            if (err)
            {
                res.statusCode = 400;

                res.end();
            }

            if (contents)
            {
                res.statusCode = 200;

                res.setHeader('Content-Type', 'text/html');

                res.write(contents);

                res.end();
            }
        }

        fileSystemModule.readFile("./news.html", handleFileRead);
    }
}

const server = httpModule.createServer(requestListener);

server.listen(3003);
