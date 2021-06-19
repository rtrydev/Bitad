import styles from "./MainButton.module.css";

function MainButton(props) {
  return <button className={styles.button}>{props.text}</button>;
}

export default MainButton;
