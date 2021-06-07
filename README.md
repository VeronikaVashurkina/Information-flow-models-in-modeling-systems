# Information-flow-models-in-modeling-systems
To model the Poisson information flow, in which the time intervals between events are distributed exponentially, it is necessary to obtain realizations of a random variable with an exponential distribution. For modeling, I determine how many events are placed in a time interval using a loop with a precondition: while the total time during which the events occurred is less than T, we simulate another value of the exponential value and try to add it to the total time.
