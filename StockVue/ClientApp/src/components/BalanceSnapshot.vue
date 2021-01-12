<template>
    <v-row>
        <v-col lg="12" md="12">
            <v-card>
                <v-list-item three-line v-if="item">
                    <v-list-item-content>
                        <div class="text-center">Account value / Today's net change</div>
                        <v-list-item-title class="text-center font-weight-bold text-h6" v-html="`<span>$</span>${item.balance}`"></v-list-item-title>
                        <v-list-item-subtitle class="text-center" v-html="`<span>$</span>${item.todaysNetChangeValue} <span>(${item.todaysNetChangePercent}%)</span>`"></v-list-item-subtitle>
                    </v-list-item-content>
                </v-list-item>
            </v-card>
        </v-col>
    </v-row>
</template>
<script>
    export default {
        name: 'BalanceSnapshot',
        computed: {
            item() {
                if (isNaN(this.$store.state.summary.balance)) {
                    return null;
                }
                return this.$store.state.summary;
            },
        },
    };
</script>