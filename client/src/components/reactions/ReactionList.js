import { useEffect, useState } from "react";
import { getReactions } from "../../managers/reactionManager";
import { Container, List, ListGroup, ListGroupItem } from "reactstrap";
import { Link } from "react-router-dom";
import defaultCatImage from '../../assets/defaultcat.png';

export default function ReactionsList() {
    const [reactions, setReactions] = useState([]);

    useEffect(() => {
        getReactions().then(setReactions)
    }, []);

    return (
        <>
            <Container>
                <List>
                    <ListGroup>
                        <Link to="create">
                            Create New Reaction
                        </Link>
                        {reactions.length > 0 &&
                            reactions.map(r => {
                                return (
                                    <ListGroupItem key={r.id}>
                                        <div>
                                            <img 
                                            src={r.imageLocation} 
                                            alt={defaultCatImage}
                                            style={{ width: "150px", height: "150px"}}/>
                                            <b>{r.name}</b>
                                        </div>
                                    </ListGroupItem>
                                )
                            })}
                    </ListGroup>
                </List>
            </Container>
        </>
    )
}