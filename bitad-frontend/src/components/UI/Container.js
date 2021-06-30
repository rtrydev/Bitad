import styles from "./Container.module.css";
import { parseClassName } from "../../hooks/custom-functions";

function Container(props) {
  return (
    <div className={`${styles.container} ${parseClassName(props.className)}`}>
      <div
        className={`${styles.container__wrapper} ${parseClassName(
          props.classNameWrapper
        )}`}
      >
        {props.children}
      </div>
    </div>
  );
}

export default Container;
