const pino = require('pino')

const logger = pino({
    prettyPrint: {
        levelFirst: true
    },
    prettifier: require('pino-pretty')
})

const processLog = (message) => {
    logger.info({ message });
}

module.exports = processLog;