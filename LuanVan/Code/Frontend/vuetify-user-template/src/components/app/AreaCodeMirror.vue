<template>
  <div>
    <!-- CodeMirror container -->
    <div ref="codeMirror"></div>

    <!-- Button to run the code -->
    <button @click="runCode()">Run Code</button>

    <!-- Display the output -->
    <div>
      <h3>Output:</h3>
      <div v-for="(item, index) in output" :key="index">
        <div>
          Testcase {{ index + 1 }}:
          <v-icon v-if="item.expected == item.actual" color="success"
            >mdi-check</v-icon
          >
          <v-icon v-else color="error">mdi-close</v-icon>
        </div>
        <div class="ml-4">Expected result: {{ item.expected }}</div>
        <div class="ml-4">Actual result: {{ item.actual }}</div>
      </div>
    </div>
  </div>
</template>

<script>
// Import CodeMirror styles
import "codemirror/lib/codemirror.css";

// Import CodeMirror script
import CodeMirror from "codemirror";
import "codemirror/mode/javascript/javascript";
export default {
  data() {
    return {
      code: "",
      output: []
    };
  },
  props: {
    practice: {
      type: Object
    }
  },
  mounted() {
    // Initialize CodeMirror
    this.editor = CodeMirror(this.$refs.codeMirror, {
      value: `${this.code}`,
      mode: "javascript",
      theme: "default",
      lineNumbers: true
    });
  },
  methods: {
    runCode() {
      try {
        // Get the code from the CodeMirror instance
        const code = this.editor.getValue();
        const wrapCode = `window.${code}`;
        eval(wrapCode);
        this.output = this.practice.testCases.map(testCase => {
          return {
            expected: testCase.expected,
            actual: window[this.practice.functionName](testCase.input)
          };
        });
      } catch (error) {
        this.output = `Error: ${error.message}`;
      }
    }
  }
};
</script>
