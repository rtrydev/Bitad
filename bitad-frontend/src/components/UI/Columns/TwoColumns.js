import styles from "./TwoColumns.module.css";

function TwoColumns(props) {
  return <div className={styles["two-columns"]}>{props.children}</div>;
}

export default TwoColumns;
