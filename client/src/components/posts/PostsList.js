import { useState, useEffect } from "react";
import { getAllPosts } from "../../managers/postManager";
import {
    Accordion,
    AccordionBody,
    AccordionHeader,
    AccordionItem,
    Button,
} from 'reactstrap';
import { Link } from "react-router-dom";

export default function PostsList() {
    const [posts, setPosts] = useState([]);
    const [open, setOpen] = useState('0');

    useEffect(() => {
        getAllPosts().then(setPosts);
    }, []);

    const toggle = (id) => {
        if (open === id) {
            setOpen('0');
        } else {
            setOpen(id);
        }
    };


    if (!posts.length) {
        return null;
    }
    return (
        <>
            <h1>
                Catty Posts
            </h1>
            <div>
                <Accordion open={open} toggle={toggle}>
                    {/* the below block of code displays post only if isAppoved === true */}
                    {/* {posts.map(p =>
                    p.isApproved ? (
                        <AccordionItem key={p.id}>
                            <AccordionHeader targetId={p.id.toString()}>
                                <strong>{p.title}</strong>&nbsp;&nbsp;&nbsp;&nbsp;{p.userProfile.fullName}&nbsp;&nbsp;&nbsp;&nbsp;<i>#{p.category.name}</i>
                            </AccordionHeader>
                            <AccordionBody accordionId={p.id.toString()}>
                                "insert child component here"
                            </AccordionBody>
                        </AccordionItem>
                    ) : ""
                )} */}
                    {posts.map(p =>
                        <AccordionItem key={p.id}>
                            <AccordionHeader targetId={p.id.toString()}>
                                <strong>{p.title}</strong>&nbsp;&nbsp;&nbsp;&nbsp;{p.userProfile.fullName}&nbsp;&nbsp;&nbsp;&nbsp;<i>#{p.category.name}</i>
                                <Link to={`/posts/${p.id}/comments`}>
                                    <Button>View Comments</Button>
                                </Link>
                            </AccordionHeader>
                            <AccordionBody accordionId={p.id.toString()}>
                                <div className="container">

                                    <h5> {p.title}</h5>

                                    <p>{p.imageLocation}</p>
                                    {/* tested: will not show up if it's null */}

                                    <p>Writen By {p.userProfile.identityUser.userName}</p>

                                    <p>{new Date(p.createDateTime).toLocaleDateString()}</p>
                                    {/* should be published date, but nothing is published yet. */}
                                    {/* <p>{p.publishDateTime}</p> */}

                                    <p>{p.content}</p>
                                </div>
                            </AccordionBody>
                        </AccordionItem>
                    )}
                </Accordion>
            </div>
        </>
    )
}