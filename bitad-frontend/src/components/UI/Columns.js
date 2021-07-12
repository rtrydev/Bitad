import styles from "./Columns.module.css";
import { parseClassName } from "../../hooks/custom-functions";

function Columns(props) {
  let classes = parseClassName(props.className);
  classes += props.reverse ? ` ${styles.reverse} ` : " ";
  switch (props.columns) {
    case "3":
      classes += `${styles["three-columns"]} ${styles["three-columns--small"]}`;
      break;
    case "3.5":
      classes += styles["three-columns"];
      break;
    case "4":
      classes += styles["four-columns"];
      break;
    default:
      classes += styles["two-columns"];
      break;
  }

  return <div className={classes}>{props.children}</div>;
}

export default Columns;
