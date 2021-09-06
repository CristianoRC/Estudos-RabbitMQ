const amqp = require('amqplib');

const getConnection = async () => {
    const CONNECTION_STRING = 'amqp://cristiano:123456789@localhost:5672/';
    const connectionFactory = await amqp.connect(CONNECTION_STRING);
    const connection = await connectionFactory.createChannel();

    return connection;
}

const getQueueInfo = async (connection, queueName) => {
    return await await connection.assertQueue(queueName);
}

module.exports = { getConnection, getQueueInfo };