import styles from "./NewLineText.module.css";

function NewLineText({ text }) {
  return <p className={styles.paragraph}>{text}</p>;
}

export default NewLineText;
