const { getConnection } = require('./rabbitConnection');
const processLog = require('./processLog');

const QUEUE_NAME = 'log';


const start = async () => {
    const connection = await getConnection();
    await connection.consume(QUEUE_NAME, (logMessage) => {
        processLog(JSON.parse(logMessage.content.toString()));
        connection.ack(logMessage);
    })
}

start().then();