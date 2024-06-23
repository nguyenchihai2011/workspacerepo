import React from 'react';
import SpeechRecognition, { useSpeechRecognition } from 'react-speech-recognition';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMicrophone } from '@fortawesome/free-solid-svg-icons';

const Dictaphone = () => {
    // eslint-disable-next-line
    const { transcript, listening, resetTranscript, browserSupportsSpeechRecognition } = useSpeechRecognition();

    if (!browserSupportsSpeechRecognition) {
        return <span>Browser doesn't support speech recognition.</span>;
    }

    return (
        <div>
            {/* <p>Microphone: {listening ? 'on' : 'off'}</p> */}
            <button onClick={SpeechRecognition.startListening}>
                <FontAwesomeIcon style={{ color: '#888' }} icon={faMicrophone} />
            </button>
            {/* <button onClick={SpeechRecognition.stopListening}>Stop</button> */}
            {/* <button onClick={resetTranscript}>Reset</button> */}
            {/* <p>{transcript}</p> */}
        </div>
    );
};
export default Dictaphone;
