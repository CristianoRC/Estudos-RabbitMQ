const amqp = require('amqplib');
const CONNECTION_STRING = process.env.CONNECTION_STRING;

const getConnection = async () => {
    const connectionFactory = await amqp.connect(CONNECTION_STRING);
    const connection = await connectionFactory.createChannel();
    return connection;
}

const getQueueInfo = async (connection, queueName) => {
    return await await connection.assertQueue(queueName);
}

module.exports = { getConnection, getQueueInfo };