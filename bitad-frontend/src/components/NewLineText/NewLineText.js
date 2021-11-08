function NewLineText({ text, separator = "\\n" }) {
  return text.split(separator).map((line) => <p>{line}</p>);
}

export default NewLineText;
