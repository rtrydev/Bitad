import Container from "./UI/Container";
import styles from "./TwoColumns.module.css";

function TwoColumns(props) {
  return (
    <Container className="">
      <section className={styles["two-columns"]}>
        <div>{props.firstColumnChildren}</div>
        <div>{props.secondColumnChildren}</div>
      </section>
    </Container>
  );
}

export default TwoColumns;
