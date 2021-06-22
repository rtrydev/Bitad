import styles from "./Columns.module.css";

function Columns(props) {
  let classes = props.reverse ? `${styles.reverse} ` : "";
  switch (props.columns) {
    case "3":
      classes += `${styles["three-columns"]} ${styles["three-columns--small"]}`;
      break;
    case "3.5":
      classes += styles["three-columns"];
      break;
    default:
      classes += styles["two-columns"];
      break;
  }

  return <div className={classes}>{props.children}</div>;
}

export default Columns;
