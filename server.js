const httpModule = require("http");
const fileSystemModule = require("fs");

const requestListener = (req, res) => {
    if (req.url === "/news")
    {
        const handleHTMLFileRead = (err, contents) => {
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

        fileSystemModule.readFile("./news.html", handleHTMLFileRead);
    }
    else if (req.url === "/news.js")
    {
        const handleJSFileRead = (err, contents) => {

            if (err)
            {
                res.statusCode = 400;
                res.end();
            }

            if (contents)
            {
                res.statusCode = 200;

                res.setHeader('Content-Type', 'application/javascript');

                res.write(contents);

                res.end();
            }
        }

        fileSystemModule.readFile("./news.js", handleJSFileRead);
    }
    else if (req.url === "/news.css")
    {
        const handleCSSFileRead = (err, contents) =>{
            if (err)
            {
                res.statusCode = 400;

                res.end();
            }

            if (contents)
            {
                res.statusCode = 200;

                res.setHeader('Content-Type', 'text/css');

                res.write(contents);

                res.end();
            }
        }

        fileSystemModule.readFile("./news.css", handleCSSFileRead);
    }
    else
    {
        const handleHTMLFileRead = (err, contents) => {
            if (err)
            {
                res.statusCode = 400;

                res.end();
            }

            if (contents)
            {
                res.statusCode = 404;

                res.setHeader('Content-Type', 'not_found.html');

                res.write(contents);

                res.end();
            }
        }
       
        fileSystemModule.readFile("./not_found.html", handleHTMLFileRead );
    }
}


const server = httpModule.createServer(requestListener);

server.listen(3003);
