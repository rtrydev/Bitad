import m from "moment";
import styles from "./TimesBar.module.css";

function TimesBar(props) {
  const times = props.times.map((time) => {
    return <span key={time}>{m(time).format("HH:mm")}</span>;
  });
  return <div className={styles["times-bar"]}>{times}</div>;
}

export default TimesBar;
