﻿var restify = require("restify");

import config from "./config";
import recordNetworkChangeRouter from "./routeRecordNetworkChange";

var server = restify.createServer();

server.use(restify.queryParser());

recordNetworkChangeRouter.applyRoutes(server);

console.log(`Listing on port ${config.HTTP_SERVER_PORT}...`);

server.listen(config.HTTP_SERVER_PORT);