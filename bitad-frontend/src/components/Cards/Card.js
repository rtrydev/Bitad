import styles from "./Card.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

function Card(props) {
  const classes = props.className !== undefined ? props.className : "";
  return (
    <div id={props.id} className={`${styles.card} ${bg.shadow} ${classes}`}>
      {props.children}
    </div>
  );
}

export default Card;
