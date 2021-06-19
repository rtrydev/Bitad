import styles from "./Card.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

function Card(props) {
  return <div className={`${styles.card} ${bg.shadow}`}>{props.children}</div>;
}

export default Card;
