import styles from "./ThreeColumns.module.css";

function ThreeColumns(props) {
  return <div className={styles["three-columns"]}>{props.children}</div>;
}

export default ThreeColumns;
